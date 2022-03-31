using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.Email;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.Email;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class AdminEmailUserPasswordResetLogic : IAdminEmailUserPasswordResetLogic
    {
        private readonly IAdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository;
        private readonly IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository;
        private readonly IAdminEmailUserPasswordResetMailLogic adminEmailUserPasswordResetMailLogic;
        private readonly IEmailClient emailClient;
        private readonly IBsiPasswordHasher bsiPasswordHasher;
        private readonly ISHA256TokenGenerator sha256TokenGenerator;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly ILogger<AdminEmailUserPasswordResetLogic> logger;
        private readonly AdminEmailUserPasswordResetOptions options;

        public AdminEmailUserPasswordResetLogic(
            IAdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository,
            IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository,
            IAdminEmailUserPasswordResetMailLogic adminEmailUserPasswordResetMailLogic,
            IEmailClient emailClient,
            IBsiPasswordHasher bsiPasswordHasher,
            ISHA256TokenGenerator sha256TokenGenerator,
            IDateTimeProvider dateTimeProvider,
            ILogger<AdminEmailUserPasswordResetLogic> logger,
            IOptions<AdminEmailUserPasswordResetOptions> options)
        {
            this.adminEmailUserPasswordResetTokenRepository = adminEmailUserPasswordResetTokenRepository;
            this.adminEmailUsersCrudRepository = adminEmailUsersCrudRepository;
            this.adminEmailUserPasswordResetMailLogic = adminEmailUserPasswordResetMailLogic;
            this.emailClient = emailClient;
            this.bsiPasswordHasher = bsiPasswordHasher;
            this.sha256TokenGenerator = sha256TokenGenerator;
            this.dateTimeProvider = dateTimeProvider;
            this.logger = logger;
            this.options = options.Value;
        }

        public ILogicResult InitializePasswordReset(string email, IBrowserInfo browserInfo)
        {
            var adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(email);

            if (adminEmailUser == null)
            {
                this.logger.LogDebug("AdminEmailUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUser konnte nicht gefunden werden.");
            }

            DbAdminEmailUserPasswordResetToken token = this.CreateToken(adminEmailUser);

            this.adminEmailUserPasswordResetTokenRepository.CreateToken(token);

            this.SendPasswordResetMail(email, token, browserInfo);

            this.logger.LogInformation("Passwort-Reset wurde gestartet und eine Mail an {email} versendet", email);
            return LogicResult.Ok();
        }

        public ILogicResult ResetPassword(string adminEmailUserPasswordResetToken, string newPassword)
        {
            var adminEmailUserPasswordResetTokenInfo = this.adminEmailUserPasswordResetTokenRepository.GetToken(adminEmailUserPasswordResetToken);

            if (adminEmailUserPasswordResetTokenInfo == null || adminEmailUserPasswordResetTokenInfo.ExpiresOn <= this.dateTimeProvider.Now())
            {
                this.logger.LogDebug("AdminEmailUserPasswordResetToken konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUserPasswordResetToken konnte nicht gefunden werden.");
            }

            this.adminEmailUserPasswordResetTokenRepository.DeleteToken(adminEmailUserPasswordResetToken);

            IDbAdminEmailUser adminEmailUser = this.adminEmailUsersCrudRepository.GetGlobalAdminEmailUser(adminEmailUserPasswordResetTokenInfo.AdminEmailUserId);
            this.UpdateAdminEmailUserWithNewPassword(adminEmailUser, newPassword);

            this.logger.LogInformation("Der AdminEmailUser {email} hat sein Passwort über die Passwort-Zurücksetzen-Funktion neu vergeben", adminEmailUser.Email);
            return LogicResult.Ok();
        }

        private DbAdminEmailUserPasswordResetToken CreateToken(IDbAdminEmailUser adminEmailUser)
        {
            return new DbAdminEmailUserPasswordResetToken()
            {
                Token = this.sha256TokenGenerator.Generate(),
                ExpiresOn = this.dateTimeProvider.Now().AddMinutes(this.options.ExpirationTimeInMinutes),
                AdminEmailUserId = adminEmailUser.Id
            };
        }

        private void SendPasswordResetMail(string email, DbAdminEmailUserPasswordResetToken adminEmailUserPasswordResetToken, IBrowserInfo browserInfo)
        {
            string mailMessage = this.adminEmailUserPasswordResetMailLogic.GetMessage(new AdminEmailUserPasswordResetMailMetadata()
            {
                MailResetPasswordUrlPrefix = this.options.MailResetPasswordUrlPrefix,
                MailHomepageUrl = this.options.MailHomepageUrl,
                MailSupportUrl = this.options.MailSupportUrl,
                AdminEmailUserEmail = email,
                AdminEmailUserPasswordResetToken = adminEmailUserPasswordResetToken.Token,
                AdminEmailUserBrowserInfo = browserInfo
            });

            this.emailClient.Send(new Email()
            {
                To = email,
                Subject = "[[Produktname]] Passwort zurücksetzen",
                Message = mailMessage
            });
        }

        private void UpdateAdminEmailUserWithNewPassword(IDbAdminEmailUser adminEmailUser, string newPassword)
        {
            IBsiPasswordHash hash = this.bsiPasswordHasher.HashPassword(newPassword);
            adminEmailUser.PasswordHash = hash.PasswordHash;
            adminEmailUser.PasswordSalt = hash.Salt;
            this.adminEmailUsersCrudRepository.UpdateGlobalAdminEmailUser(adminEmailUser);
        }
    }
}