using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUserPasswordChangeLogic : IAdminEmailUserPasswordChangeLogic
    {
        private readonly IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository;

        private readonly ISessionContext sessionContext;

        private readonly IBsiPasswordHasher bsiPasswordHasher;
        private readonly ILogger<AdminEmailUserPasswordChangeLogic> logger;

        public AdminEmailUserPasswordChangeLogic(
            IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository,
            ISessionContext sessionContext,
            IBsiPasswordHasher bsiPasswordHasher,
            ILogger<AdminEmailUserPasswordChangeLogic> logger)
        {
            this.adminEmailUsersCrudRepository = adminEmailUsersCrudRepository;

            this.sessionContext = sessionContext;

            this.bsiPasswordHasher = bsiPasswordHasher;
            this.logger = logger;
        }

        public ILogicResult ChangePassword(string oldPassword, string newPassword)
        {
            if (!this.sessionContext.AdminEmailUserId.HasValue)
            {
                this.logger.LogWarning("Ein User, der nicht AdminEmailUser ist, hat versucht sein AdminEmailUser-Passwort zu ändern.");
                return LogicResult.Forbidden();
            }

            IDbAdminEmailUser adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(this.sessionContext.AdminEmailUserId.Value);
            if (!this.IsPasswordValid(oldPassword, adminEmailUser))
            {
                this.logger.LogWarning("Das alte Passwort ist falsch.");
                return LogicResult.Forbidden();
            }

            this.UpdateAdminEmailUserWithNewPassword(adminEmailUser, newPassword);

            this.logger.LogInformation("Das Passwort wurde mit der Passwort-Ändern-Funktion neu vergeben.");
            return LogicResult.Ok();
        }

        private void UpdateAdminEmailUserWithNewPassword(IDbAdminEmailUser adminEmailUser, string newPassword)
        {
            IBsiPasswordHash hash = this.bsiPasswordHasher.HashPassword(newPassword);
            adminEmailUser.PasswordHash = hash.PasswordHash;
            adminEmailUser.PasswordSalt = hash.Salt;
            this.adminEmailUsersCrudRepository.UpdateAdminEmailUser(adminEmailUser);
        }

        private bool IsPasswordValid(string password, IDbAdminEmailUser adminEmailUser)
        {
            return this.bsiPasswordHasher.ComparePasswords(password, adminEmailUser.PasswordHash, adminEmailUser.PasswordSalt);
        }
    }
}