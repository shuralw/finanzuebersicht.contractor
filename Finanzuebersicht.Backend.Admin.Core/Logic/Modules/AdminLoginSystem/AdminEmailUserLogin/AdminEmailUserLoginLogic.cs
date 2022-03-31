using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserLogin
{
    internal class AdminEmailUserLoginLogic : IAdminEmailUserLoginLogic
    {
        private readonly IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository;
        private readonly IAdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic;
        private readonly IAdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic;

        private readonly IBsiPasswordHasher bsiPasswordHasher;
        private readonly ILogger<AdminEmailUserLoginLogic> logger;

        public AdminEmailUserLoginLogic(
            IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository,
            IAdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic,
            IAdminRefreshTokensCrudLogic adminRefreshTokensCrudLogic,
            IBsiPasswordHasher bsiPasswordHasher,
            ILogger<AdminEmailUserLoginLogic> logger)
        {
            this.adminEmailUsersCrudRepository = adminEmailUsersCrudRepository;
            this.adminEmailUserFailedLoginAttemptsLogic = adminEmailUserFailedLoginAttemptsLogic;
            this.adminRefreshTokensCrudLogic = adminRefreshTokensCrudLogic;

            this.bsiPasswordHasher = bsiPasswordHasher;
            this.logger = logger;
        }

        public ILogicResult<IAdminRefreshTokenDetail> LoginAsAdminEmailUser(string email, string password)
        {
            var validateLoginDataResult = this.ValidateLoginData(email, password);
            if (!validateLoginDataResult.IsSuccessful)
            {
                return LogicResult<IAdminRefreshTokenDetail>.Forward(validateLoginDataResult);
            }

            IDbAdminEmailUser adminEmailUser = validateLoginDataResult.Data;
            Guid adminRefreshTokensId = this.adminRefreshTokensCrudLogic.CreateAdminRefreshTokenForAdminEmailUser(adminEmailUser.Id, adminEmailUser.Email);

            IAdminRefreshTokenDetail adminRefreshTokenDetail = this.adminRefreshTokensCrudLogic.GetAdminRefreshToken(adminRefreshTokensId).Data;

            this.logger.LogInformation(
                $"E-Mail-Benutzer-Login erfolgreich für {adminEmailUser.Email}");

            return LogicResult<IAdminRefreshTokenDetail>.Ok(adminRefreshTokenDetail);
        }

        private ILogicResult<IDbAdminEmailUser> ValidateLoginData(string email, string password)
        {
            email = email.ToLower();
            IDbAdminEmailUser adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(email);

            if (adminEmailUser == null)
            {
                this.logger.LogWarning($"E-Mail ({email}) nicht korrekt.");
                return LogicResult<IDbAdminEmailUser>.NotFound("E-Mail oder Passwort nicht korrekt");
            }

            if (this.adminEmailUserFailedLoginAttemptsLogic.HasAdminEmailUserTooManyFailedLoginAttempts(adminEmailUser.Id))
            {
                this.logger.LogWarning($"Zu viele fehlgeschlagene Login-Versuche für {adminEmailUser.Email}.");
                return LogicResult<IDbAdminEmailUser>.Forbidden("Zu viele fehlgeschlagene Login-Versuche.");
            }

            if (!this.IsPasswordValid(password, adminEmailUser))
            {
                this.adminEmailUserFailedLoginAttemptsLogic.AddFailedLoginAttempt(adminEmailUser.Id);
                this.logger.LogWarning($"Passwort nicht korrekt für {adminEmailUser.Email}.");
                return LogicResult<IDbAdminEmailUser>.NotFound("E-Mail oder Passwort nicht korrekt");
            }

            this.adminEmailUserFailedLoginAttemptsLogic.RemoveFailedLoginAttempts(adminEmailUser.Id);

            return LogicResult<IDbAdminEmailUser>.Ok(adminEmailUser);
        }

        private bool IsPasswordValid(string password, IDbAdminEmailUser adminEmailUser)
        {
            return this.bsiPasswordHasher.ComparePasswords(password, adminEmailUser.PasswordHash, adminEmailUser.PasswordSalt);
        }
    }
}