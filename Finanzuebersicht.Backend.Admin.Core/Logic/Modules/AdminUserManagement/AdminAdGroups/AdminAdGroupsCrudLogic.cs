using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdGroups
{
    internal class AdminAdGroupsCrudLogic : IAdminAdGroupsCrudLogic
    {
        private readonly IAdminAdGroupsCrudRepository adminAdGroupsCrudRepository;
        private readonly IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository;
        private readonly IAdminAdGroupMembershipRepository adminAdGroupMembershipRepository;
        private readonly IAdPermissionsCalculationLogic adPermissionsCalculationLogic;
        private readonly IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<AdminAdGroupsCrudLogic> logger;

        public AdminAdGroupsCrudLogic(
            IAdminAdGroupsCrudRepository adminAdGroupsCrudRepository,
            IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository,
            IAdminAdGroupMembershipRepository adminAdGroupMembershipRepository,
            IAdPermissionsCalculationLogic adPermissionsCalculationLogic,
            IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<AdminAdGroupsCrudLogic> logger)
        {
            this.adminAdGroupsCrudRepository = adminAdGroupsCrudRepository;
            this.adminUserGroupsCrudRepository = adminUserGroupsCrudRepository;
            this.adminAdGroupMembershipRepository = adminAdGroupMembershipRepository;
            this.adPermissionsCalculationLogic = adPermissionsCalculationLogic;
            this.adminAccessTokensCrudRepository = adminAccessTokensCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<IPagedResult<IAdminAdGroup>> GetPagedAdminAdGroups()
        {
            IDbPagedResult<IDbAdminAdGroup> dbAdminAdGroupsPagedResult = this.adminAdGroupsCrudRepository.GetPagedAdminAdGroups();

            IPagedResult<IAdminAdGroup> adminAdGroupPagedResult = PagedResult.FromDbPagedResult(
                dbAdminAdGroupsPagedResult,
                e => AdminAdGroup.FromDbAdminAdGroup(e));

            this.logger.LogDebug("AdminAdGroups wurden geladen");
            return LogicResult<IPagedResult<IAdminAdGroup>>.Ok(adminAdGroupPagedResult);
        }

        public ILogicResult<IAdminAdGroupDetail> GetAdminAdGroupDetail(Guid adminAdGroupId)
        {
            IDbAdminAdGroup adminAdGroup = this.adminAdGroupsCrudRepository.GetAdminAdGroup(adminAdGroupId);
            if (adminAdGroup == null)
            {
                this.logger.LogDebug("AD-Gruppe konnte nicht gefunden werden.");
                return LogicResult<IAdminAdGroupDetail>.NotFound("AD-Gruppe konnte nicht gefunden werden.");
            }

            var calculatedPermissions = this.adPermissionsCalculationLogic.CalculatePermissionsForAd(null, new List<Guid>() { adminAdGroupId });

            IEnumerable<IAdminUserGroup> adminUserGroups = this.adminAdGroupMembershipRepository.GetAdminUserGroupsOfAdminAdGroup(adminAdGroupId)
                .Select(adminUserGroup => AdminUserGroup.FromDbAdminUserGroup(adminUserGroup));

            AdminAdGroupDetail adminAdGroupDetail = new AdminAdGroupDetail()
            {
                Id = adminAdGroup.Id,
                Dn = adminAdGroup.Dn,
                Permissions = adminAdGroup.Permissions,
                CalculatedPermissions = calculatedPermissions,
                ParentAdminUserGroups = adminUserGroups
            };

            this.logger.LogDebug("Details für AD-Gruppe wurde geladen");
            return LogicResult<IAdminAdGroupDetail>.Ok(adminAdGroupDetail);
        }

        public ILogicResult<Guid> CreateAdminAdGroup(string dn)
        {
            if (this.adminAdGroupsCrudRepository.DoesAdminAdGroupExist(dn))
            {
                this.logger.LogDebug("AD-Gruppe mit diesem Distinguished Name existiert bereits.");
                return LogicResult<Guid>.Conflict("AD-Gruppe mit diesem Distinguished Name existiert bereits.");
            }

            DbAdminAdGroup adminAdGroupToAdd = this.CreateNewAdminAdGroup(dn);
            this.adminAdGroupsCrudRepository.CreateAdminAdGroup(adminAdGroupToAdd);

            this.logger.LogInformation("AD-Gruppe ({dn}) angelegt", dn);
            return LogicResult<Guid>.Ok(adminAdGroupToAdd.Id);
        }

        public ILogicResult UpdateAdminAdGroup(Guid adminAdGroupId, string newDn)
        {
            if (this.adminAdGroupsCrudRepository.DoesAdminAdGroupExist(newDn))
            {
                this.logger.LogDebug("AD-Gruppe mit diesem Distinguished Name existiert bereits.");
                return LogicResult.Conflict("AD-Gruppe mit diesem Distinguished Name existiert bereits.");
            }

            IDbAdminAdGroup adminAdGroupToUpdate = this.adminAdGroupsCrudRepository.GetAdminAdGroup(adminAdGroupId);
            if (adminAdGroupToUpdate == null)
            {
                this.logger.LogDebug("AD-Gruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AD-Gruppe konnte nicht gefunden werden.");
            }

            var adminAdGroupDnBefore = adminAdGroupToUpdate.Dn;
            adminAdGroupToUpdate.Dn = newDn;
            this.adminAdGroupsCrudRepository.UpdateAdminAdGroup(adminAdGroupToUpdate);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("AD-Gruppe ({adminAdGroupDnBefore}) umbenannt zu {adminAdGroupDn}", adminAdGroupDnBefore, newDn);
            return LogicResult.Ok();
        }

        public ILogicResult DeleteAdminAdGroup(Guid adminAdGroupId)
        {
            IDbAdminAdGroup adminAdGroupToDelete = this.adminAdGroupsCrudRepository.GetAdminAdGroup(adminAdGroupId);
            if (adminAdGroupToDelete == null)
            {
                this.logger.LogDebug("AD-Gruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AD-Gruppe konnte nicht gefunden werden.");
            }

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.adminAdGroupsCrudRepository.DeleteAdminAdGroup(adminAdGroupToDelete.Id);

            this.logger.LogInformation("AD-Gruppe ({dn}) gelöscht", adminAdGroupToDelete.Dn);
            return LogicResult.Ok();
        }

        public ILogicResult UpdateAdminAdGroupPermissions(Guid adminAdGroupId, IDictionary<string, PermissionStatus> permissionsUpdate)
        {
            IDbAdminAdGroup adminAdGroup = this.adminAdGroupsCrudRepository.GetAdminAdGroup(adminAdGroupId);
            if (adminAdGroup == null)
            {
                this.logger.LogDebug("AD-Gruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AD-Gruppe konnte nicht gefunden werden.");
            }

            adminAdGroup.Permissions = permissionsUpdate;
            this.adminAdGroupsCrudRepository.UpdateAdminAdGroup(adminAdGroup);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("Berechtigungen für AD-Gruppe ({dn}) geändert: {permissions}", adminAdGroup.Dn, string.Join(";", permissionsUpdate));
            return LogicResult.Ok();
        }

        public ILogicResult AddAdminAdGroupToAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId)
        {
            var adminAdGroup = this.adminAdGroupsCrudRepository.GetAdminAdGroup(adminAdGroupId);
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);

            if (adminAdGroup == null || adminUserGroup == null)
            {
                this.logger.LogDebug("AD-Gruppe oder Benutzergruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AD-Gruppe oder Benutzergruppe konnte nicht gefunden werden.");
            }

            this.adminAdGroupMembershipRepository.AddAdminAdGroupToAdminUserGroup(adminAdGroupId, adminUserGroupId);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("AD-Gruppe ({dn}) zu Gruppe ({adminUserGroupname}) hinzugefügt", adminAdGroup.Dn, adminUserGroup.Name);
            return LogicResult.Ok();
        }

        public ILogicResult RemoveAdminAdGroupFromAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId)
        {
            var adminAdGroup = this.adminAdGroupsCrudRepository.GetAdminAdGroup(adminAdGroupId);
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);

            if (adminAdGroup == null || adminUserGroup == null)
            {
                this.logger.LogDebug("AD-Gruppe oder Benutzergruppe konnte nicht gefunden werden.");
                return LogicResult.NotFound("AD-Gruppe oder Benutzergruppe konnte nicht gefunden werden.");
            }

            this.adminAdGroupMembershipRepository.RemoveAdminAdGroupFromAdminUserGroup(adminAdGroupId, adminUserGroupId);

            this.adminAccessTokensCrudRepository.DeleteAdminAccessTokensOfAdminAdUsersAndAdminAdGroups();

            this.logger.LogInformation("AD-Gruppe ({dn}) aus Gruppe ({adminUserGroupname}) entfernt", adminAdGroup.Dn, adminUserGroup.Name);
            return LogicResult.Ok();
        }

        private DbAdminAdGroup CreateNewAdminAdGroup(string dn)
        {
            return new DbAdminAdGroup()
            {
                Id = this.guidGenerator.NewGuid(),
                Dn = dn,
                Permissions = PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.NOT_SET)
            };
        }
    }
}