using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUsersCrudLogic : IAdminAdUsersCrudLogic
    {
        private readonly IAdminAdUsersCrudRepository adminAdUsersCrudRepository;
        private readonly IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository;
        private readonly IAdminAdUserMembershipRepository adminAdUserMembershipRepository;
        private readonly IAdPermissionsCalculationLogic adPermissionsCalculationLogic;
        private readonly IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<AdminAdUsersCrudLogic> logger;

        public AdminAdUsersCrudLogic(
            IAdminAdUsersCrudRepository adminAdUsersCrudRepository,
            IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository,
            IAdminAdUserMembershipRepository adminAdUserMembershipRepository,
            IAdPermissionsCalculationLogic adPermissionsCalculationLogic,
            IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<AdminAdUsersCrudLogic> logger)
        {
            this.adminAdUsersCrudRepository = adminAdUsersCrudRepository;
            this.adminUserGroupsCrudRepository = adminUserGroupsCrudRepository;
            this.adminAdUserMembershipRepository = adminAdUserMembershipRepository;
            this.adPermissionsCalculationLogic = adPermissionsCalculationLogic;
            this.adminAccessTokensCrudRepository = adminAccessTokensCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<IPagedResult<IAdminAdUser>> GetPagedAdminAdUsers()
        {
            IDbPagedResult<IDbAdminAdUser> dbAdminAdUsersPagedResult = this.adminAdUsersCrudRepository.GetPagedAdminAdUsers();

            IPagedResult<IAdminAdUser> adminAdUserPagedResult = PagedResult.FromDbPagedResult(
                dbAdminAdUsersPagedResult,
                e => AdminAdUser.FromDbAdminAdUser(e));

            this.logger.LogDebug("AdminAdUsers wurden geladen");
            return LogicResult<IPagedResult<IAdminAdUser>>.Ok(adminAdUserPagedResult);
        }

        public ILogicResult<IAdminAdUserDetail> GetAdminAdUserDetail(Guid adminAdUserId)
        {
            IDbAdminAdUser adminAdUser = this.adminAdUsersCrudRepository.GetAdminAdUser(adminAdUserId);
            if (adminAdUser == null)
            {
                this.logger.LogDebug("AdminAdUser konnte nicht gefunden werden.");
                return LogicResult<IAdminAdUserDetail>.NotFound("AdminAdUser konnte nicht gefunden werden.");
            }

            var calculatedPermissions = this.adPermissionsCalculationLogic
                .CalculatePermissionsForAd(adminAdUserId, Array.Empty<Guid>());

            IEnumerable<IAdminUserGroup> adminUserGroups = this.adminAdUserMembershipRepository.GetAdminUserGroupsOfAdminAdUser(adminAdUserId)
                .Select(adminUserGroup => AdminUserGroup.FromDbAdminUserGroup(adminUserGroup));

            AdminAdUserDetail adminAdUserDetail = new AdminAdUserDetail()
            {
                Id = adminAdUser.Id,
                Dn = adminAdUser.Dn,
                Permissions = adminAdUser.Permissions,
                CalculatedPermissions = calculatedPermissions,
                ParentAdminUserGroups = adminUserGroups
            };

            this.logger.LogDebug("Details für AdminAdUser wurde geladen");
            return LogicResult<IAdminAdUserDetail>.Ok(adminAdUserDetail);
        }

        public ILogicResult<Guid> CreateAdminAdUser(string dn)
        {
            if (this.adminAdUsersCrudRepository.DoesAdminAdUserExist(dn))
            {
                this.logger.LogDebug("AdminAdUser mit diesem Distinguished Name existiert bereits.");
                return LogicResult<Guid>.Conflict("AdminAdUser mit diesem Distinguished Name existiert bereits.");
            }

            DbAdminAdUser adminAdUserToAdd = this.CreateNewAdminAdUser(dn);
            this.adminAdUsersCrudRepository.CreateAdminAdUser(adminAdUserToAdd);

            this.logger.LogInformation("AdminAdUser ({dn}) angelegt", dn);
            return LogicResult<Guid>.Ok(adminAdUserToAdd.Id);
        }

        public ILogicResult UpdateAdminAdUser(Guid adminAdUserId, string newDn)
        {
            if (this.adminAdUsersCrudRepository.DoesAdminAdUserExist(newDn))
            {
                this.logger.LogDebug("AdminAdUser mit diesem Distinguished Name existiert bereits.");
                return LogicResult.Conflict("AdminAdUser mit diesem Distinguished Name existiert bereits.");
            }

            IDbAdminAdUser adminAdUserToUpdate = this.adminAdUsersCrudRepository.GetAdminAdUser(adminAdUserId);
            if (adminAdUserToUpdate == null)
            {
                this.logger.LogDebug("AdminAdUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminAdUser konnte nicht gefunden werden.");
            }

            var adminAdUserDnBefore = adminAdUserToUpdate.Dn;

            adminAdUserToUpdate.Dn = newDn;
            this.adminAdUsersCrudRepository.UpdateAdminAdUser(adminAdUserToUpdate);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("AdminAdUser ({adminAdUserDnBefore}) umbenannt zu {adminAdUserDn}", adminAdUserDnBefore, newDn);
            return LogicResult.Ok();
        }

        public ILogicResult DeleteAdminAdUser(Guid adminAdUserId)
        {
            IDbAdminAdUser adminAdUserToDelete = this.adminAdUsersCrudRepository.GetAdminAdUser(adminAdUserId);
            if (adminAdUserToDelete == null)
            {
                this.logger.LogDebug("AdminAdUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminAdUser konnte nicht gefunden werden.");
            }

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.adminAdUsersCrudRepository.DeleteAdminAdUser(adminAdUserToDelete.Id);

            this.logger.LogInformation("AdminAdUser ({dn}) gelöscht", adminAdUserToDelete.Dn);
            return LogicResult.Ok();
        }

        public ILogicResult UpdateAdminAdUserPermissions(Guid adminAdUserId, IDictionary<string, PermissionStatus> permissionsUpdate)
        {
            IDbAdminAdUser adminAdUser = this.adminAdUsersCrudRepository.GetAdminAdUser(adminAdUserId);
            if (adminAdUser == null)
            {
                this.logger.LogDebug("AdminAdUser konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminAdUser konnte nicht gefunden werden.");
            }

            adminAdUser.Permissions = permissionsUpdate;
            this.adminAdUsersCrudRepository.UpdateAdminAdUser(adminAdUser);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("Berechtigungen für AdminAdUser ({dn}) geändert: {permissions}", adminAdUser.Dn, string.Join(";", permissionsUpdate));
            return LogicResult.Ok();
        }

        public ILogicResult AddAdminAdUserToAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId)
        {
            var adminAdUser = this.adminAdUsersCrudRepository.GetAdminAdUser(adminAdUserId);
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);

            if (adminAdUser == null || adminUserGroup == null)
            {
                this.logger.LogDebug("AdminAdUser oder Benutzergruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminAdUser oder Benutzergruppe konnte nicht gefunden werden.");
            }

            this.adminAdUserMembershipRepository.AddAdminAdUserToAdminUserGroup(adminAdUserId, adminUserGroupId);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("AdminAdUser ({dn}) zu Gruppe ({adminUserGroupname}) hinzugefügt", adminAdUser.Dn, adminUserGroup.Name);
            return LogicResult.Ok();
        }

        public ILogicResult RemoveAdminAdUserFromAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId)
        {
            var adminAdUser = this.adminAdUsersCrudRepository.GetAdminAdUser(adminAdUserId);
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);

            if (adminAdUser == null || adminUserGroup == null)
            {
                this.logger.LogDebug("AdminAdUser oder Benutzergruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminAdUser oder Benutzergruppe konnte nicht gefunden werden.");
            }

            this.adminAdUserMembershipRepository.RemoveAdminAdUserFromAdminUserGroup(adminAdUserId, adminUserGroupId);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("AdminAdUser ({dn}) aus Gruppe ({adminUserGroupname}) entfernt", adminAdUser.Dn, adminUserGroup.Name);
            return LogicResult.Ok();
        }

        private DbAdminAdUser CreateNewAdminAdUser(string dn)
        {
            return new DbAdminAdUser()
            {
                Id = this.guidGenerator.NewGuid(),
                Dn = dn,
                Permissions = PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.NOT_SET)
            };
        }
    }
}