using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Contexts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUsersCrudLogic : IAdminEmailUsersCrudLogic
    {
        private readonly IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository;
        private readonly IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository;
        private readonly IAdminEmailUserMembershipRepository adminEmailUserMembershipRepository;
        private readonly IAdminEmailUserPermissionsCalculationLogic adminEmailUserPermissionsCalculationLogic;
        private readonly IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository;
        private readonly IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository;

        private readonly IBsiPasswordHasher bsiPasswordHasher;
        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<AdminEmailUsersCrudLogic> logger;

        public AdminEmailUsersCrudLogic(
            IAdminEmailUsersCrudRepository adminEmailUsersCrudRepository,
            IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository,
            IAdminEmailUserMembershipRepository adminEmailUserMembershipRepository,
            IAdminEmailUserPermissionsCalculationLogic adminEmailUserPermissionsCalculationLogic,
            IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository,
            IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository,
            IBsiPasswordHasher bsiPasswordHasher,
            IGuidGenerator guidGenerator,
            ILogger<AdminEmailUsersCrudLogic> logger)
        {
            this.adminEmailUsersCrudRepository = adminEmailUsersCrudRepository;
            this.adminUserGroupsCrudRepository = adminUserGroupsCrudRepository;
            this.adminEmailUserMembershipRepository = adminEmailUserMembershipRepository;
            this.adminEmailUserPermissionsCalculationLogic = adminEmailUserPermissionsCalculationLogic;
            this.adminAccessTokensCrudRepository = adminAccessTokensCrudRepository;
            this.adminRefreshTokensCrudRepository = adminRefreshTokensCrudRepository;

            this.bsiPasswordHasher = bsiPasswordHasher;
            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<IPagedResult<IAdminEmailUser>> GetPagedAdminEmailUsers()
        {
            IDbPagedResult<IDbAdminEmailUser> dbAdminEmailUsersPagedResult = this.adminEmailUsersCrudRepository.GetPagedAdminEmailUsers();

            IPagedResult<IAdminEmailUser> adminEmailUserPagedResult = PagedResult.FromDbPagedResult(
                dbAdminEmailUsersPagedResult,
                e => AdminEmailUser.FromDbAdminEmailUser(e));

            this.logger.LogDebug("AdminEmailUsers wurden geladen");
            return LogicResult<IPagedResult<IAdminEmailUser>>.Ok(adminEmailUserPagedResult);
        }

        public ILogicResult<IAdminEmailUserDetail> GetAdminEmailUserDetail(Guid adminEmailUserId)
        {
            IDbAdminEmailUser adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(adminEmailUserId);
            if (adminEmailUser == null)
            {
                this.logger.LogDebug("AdminEmailUser konnte nicht gefunden werden.");
                return LogicResult<IAdminEmailUserDetail>.NotFound("AdminEmailUser konnte nicht gefunden werden.");
            }

            var calculatedPermissions = this.adminEmailUserPermissionsCalculationLogic.CalculatePermissionsForAdminEmailUser(adminEmailUserId);

            IEnumerable<IAdminUserGroup> adminUserGroups = this.adminEmailUserMembershipRepository.GetAdminUserGroupsOfAdminEmailUser(adminEmailUserId)
                .Select(adminUserGroup => AdminUserGroup.FromDbAdminUserGroup(adminUserGroup));

            AdminEmailUserDetail adminEmailUserDetail = new AdminEmailUserDetail()
            {
                Id = adminEmailUser.Id,
                Email = adminEmailUser.Email,
                Permissions = adminEmailUser.Permissions,
                CalculatedPermissions = calculatedPermissions,
                ParentAdminUserGroups = adminUserGroups
            };

            this.logger.LogDebug("Details für AdminEmailUser wurde geladen");
            return LogicResult<IAdminEmailUserDetail>.Ok(adminEmailUserDetail);
        }

        public ILogicResult<Guid> CreateAdminEmailUser(string email)
        {
            email = email.ToLower();
            if (this.adminEmailUsersCrudRepository.DoesAdminEmailUserExist(email))
            {
                this.logger.LogDebug("AdminEmailUser mit dieser E-Mail-Addresse existiert bereits.");
                return LogicResult<Guid>.Conflict("AdminEmailUser mit dieser E-Mail-Addresse existiert bereits.");
            }

            DbAdminEmailUser adminEmailUserToAdd = this.CreateNewAdminEmailUser(email);

            this.adminEmailUsersCrudRepository.CreateAdminEmailUser(adminEmailUserToAdd);

            this.logger.LogInformation("AdminEmailUser ({email}) angelegt", email);
            return LogicResult<Guid>.Ok(adminEmailUserToAdd.Id);
        }

        public ILogicResult UpdateAdminEmailUser(Guid adminEmailUserId, string newEmail)
        {
            IDbAdminEmailUser adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(adminEmailUserId);
            if (adminEmailUser == null)
            {
                this.logger.LogDebug("AdminEmailUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUser konnte nicht gefunden werden.");
            }

            newEmail = newEmail.ToLower();
            if (this.adminEmailUsersCrudRepository.DoesAdminEmailUserExist(newEmail))
            {
                this.logger.LogDebug("AdminEmailUser mit dieser E-Mail-Addresse existiert bereits in diesem oder einem anderen Mandnten.");
                return LogicResult.Conflict("AdminEmailUser mit dieser E-Mail-Addresse existiert bereits in diesem oder einem anderen Mandnten.");
            }

            string emailAlt = adminEmailUser.Email;
            adminEmailUser.Email = newEmail;
            this.adminEmailUsersCrudRepository.UpdateAdminEmailUser(adminEmailUser);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminEmailUser(adminEmailUserId);

            this.logger.LogInformation("AdminEmailUser ({emailAlt}) umbenannt zu {email}", emailAlt, newEmail);
            return LogicResult.Ok();
        }

        public ILogicResult DeleteAdminEmailUser(Guid adminEmailUserId)
        {
            IDbAdminEmailUser adminEmailUserToDelete = this.adminEmailUsersCrudRepository.GetAdminEmailUser(adminEmailUserId);
            if (adminEmailUserToDelete == null)
            {
                this.logger.LogDebug("AdminEmailUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUser konnte nicht gefunden werden.");
            }

            this.adminRefreshTokensCrudRepository.DeleteAdminRefreshTokensOfAdminEmailUser(adminEmailUserId);

            this.adminEmailUsersCrudRepository.DeleteAdminEmailUser(adminEmailUserToDelete.Id);

            this.logger.LogInformation("AdminEmailUser ({email}) gelöscht", adminEmailUserToDelete.Email);
            return LogicResult.Ok();
        }

        public ILogicResult UpdateAdminEmailUserPermissions(Guid adminEmailUserId, IDictionary<string, PermissionStatus> permissionsUpdate)
        {
            IDbAdminEmailUser adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(adminEmailUserId);
            if (adminEmailUser == null)
            {
                this.logger.LogDebug("AdminEmailUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUser konnte nicht gefunden werden.");
            }

            adminEmailUser.Permissions = permissionsUpdate;
            this.adminEmailUsersCrudRepository.UpdateAdminEmailUser(adminEmailUser);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminEmailUser(adminEmailUserId);

            this.logger.LogInformation("Berechtigungen für AdminEmailUser ({email}) geändert: {permissions}", adminEmailUser.Email, string.Join(";", permissionsUpdate));
            return LogicResult.Ok();
        }

        public ILogicResult AddAdminEmailUserToAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId)
        {
            var adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(adminEmailUserId);
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);

            if (adminEmailUser == null || adminUserGroup == null)
            {
                this.logger.LogDebug("AdminEmailUser oder AdminUserGroup konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUser oder AdminUserGroup konnte nicht gefunden werden.");
            }

            this.adminEmailUserMembershipRepository.AddAdminEmailUserToAdminUserGroup(adminEmailUserId, adminUserGroupId);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminEmailUser(adminEmailUserId);

            this.logger.LogInformation("AdminEmailUser ({email}) zu Gruppe ({adminUserGroupname}) hinzugefügt", adminEmailUser.Email, adminUserGroup.Name);
            return LogicResult.Ok();
        }

        public ILogicResult RemoveAdminEmailUserFromAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId)
        {
            var adminEmailUser = this.adminEmailUsersCrudRepository.GetAdminEmailUser(adminEmailUserId);
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);

            if (adminEmailUser == null || adminUserGroup == null)
            {
                this.logger.LogDebug("AdminEmailUser oder Benutzergruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminEmailUser oder Benutzergruppe konnte nicht gefunden werden.");
            }

            this.adminEmailUserMembershipRepository.RemoveAdminEmailUserFromAdminUserGroup(adminEmailUserId, adminUserGroupId);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminEmailUser(adminEmailUserId);

            this.logger.LogInformation("AdminEmailUser ({email}) aus Gruppe ({adminUserGroupname}) entfernt", adminEmailUser.Email, adminUserGroup.Name);
            return LogicResult.Ok();
        }

        private DbAdminEmailUser CreateNewAdminEmailUser(string email)
        {
            IBsiPasswordHash password = this.bsiPasswordHasher.HashPassword(this.guidGenerator.NewGuid().ToString());

            return new DbAdminEmailUser()
            {
                Id = this.guidGenerator.NewGuid(),
                Email = email,
                PasswordHash = password.PasswordHash,
                PasswordSalt = password.Salt,
                Permissions = PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.NOT_SET)
            };
        }
    }
}