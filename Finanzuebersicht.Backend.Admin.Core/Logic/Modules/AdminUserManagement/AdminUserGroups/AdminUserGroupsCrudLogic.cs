using Microsoft.Extensions.Logging;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using Finanzuebersicht.Backend.Admin.Core.Logic.LogicResults;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroupsCrudLogic : IAdminUserGroupsCrudLogic
    {
        private readonly IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository;
        private readonly IAdminUserGroupMembershipRepository adminUserGroupMembershipRepository;
        private readonly IAdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic;
        private readonly IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository;

        private readonly IGuidGenerator guidGenerator;
        private readonly ILogger<AdminUserGroupsCrudLogic> logger;

        public AdminUserGroupsCrudLogic(
            IAdminUserGroupsCrudRepository adminUserGroupsCrudRepository,
            IAdminUserGroupMembershipRepository adminUserGroupMembershipRepository,
            IAdminUserGroupPermissionsCalculationLogic adminUserGroupPermissionsCalculationLogic,
            IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository,
            IGuidGenerator guidGenerator,
            ILogger<AdminUserGroupsCrudLogic> logger)
        {
            this.adminUserGroupsCrudRepository = adminUserGroupsCrudRepository;
            this.adminUserGroupMembershipRepository = adminUserGroupMembershipRepository;
            this.adminUserGroupPermissionsCalculationLogic = adminUserGroupPermissionsCalculationLogic;
            this.adminAccessTokensCrudRepository = adminAccessTokensCrudRepository;

            this.guidGenerator = guidGenerator;
            this.logger = logger;
        }

        public ILogicResult<IPagedResult<IAdminUserGroup>> GetPagedAdminUserGroups()
        {
            IDbPagedResult<IDbAdminUserGroup> dbAdminUserGroupsPagedResult = this.adminUserGroupsCrudRepository.GetPagedAdminUserGroups();

            IPagedResult<IAdminUserGroup> adminEmailUserPagedResult = PagedResult.FromDbPagedResult(
                dbAdminUserGroupsPagedResult,
                dbAdminUserGroup => AdminUserGroup.FromDbAdminUserGroup(dbAdminUserGroup));

            this.logger.LogDebug("AdminUserGroups wurden geladen");
            return LogicResult<IPagedResult<IAdminUserGroup>>.Ok(adminEmailUserPagedResult);
        }

        public ILogicResult<IAdminUserGroupDetail> GetAdminUserGroupDetail(Guid adminUserGroupId)
        {
            IDbAdminUserGroup adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);
            if (adminUserGroup == null)
            {
                this.logger.LogDebug("AdminUserGroup konnte nicht gefunden werden.");
                return LogicResult<IAdminUserGroupDetail>.NotFound("AdminUserGroup konnte nicht gefunden werden.");
            }

            var calculatedPermissions = this.adminUserGroupPermissionsCalculationLogic.CalculatePermissionsForAdminUserGroups(new List<IDbAdminUserGroup>() { adminUserGroup });

            IEnumerable<IAdminUserGroup> parentAdminUserGroups = this.adminUserGroupMembershipRepository.GetAdminUserGroupParentsOfAdminUserGroup(adminUserGroupId)
                .Select(dbAdminUserGroup => new AdminUserGroup() { Id = dbAdminUserGroup.Id, Name = dbAdminUserGroup.Name });

            IEnumerable<IAdminEmailUser> adminEmailUserMembers = this.adminUserGroupMembershipRepository.GetAdminEmailUsersOfAdminUserGroup(adminUserGroupId)
                .Select(dbAdminEmailUser => new AdminEmailUser() { Id = dbAdminEmailUser.Id, Email = dbAdminEmailUser.Email });
            IEnumerable<IAdminUserGroup> adminUserGroupMembers = this.adminUserGroupMembershipRepository.GetAdminUserGroupsOfAdminUserGroup(adminUserGroupId)
                .Select(dbAdminUserGroup => new AdminUserGroup() { Id = dbAdminUserGroup.Id, Name = dbAdminUserGroup.Name });
            IEnumerable<IAdminAdUser> adminAdUserMembers = this.adminUserGroupMembershipRepository.GetAdminAdUsersOfAdminUserGroup(adminUserGroupId)
                .Select(dbAdminAdUser => new AdminAdUser() { Id = dbAdminAdUser.Id, Dn = dbAdminAdUser.Dn });
            IEnumerable<IAdminAdGroup> adminAdGroupMembers = this.adminUserGroupMembershipRepository.GetAdminAdGroupsOfAdminUserGroup(adminUserGroupId)
                .Select(dbAdminAdGroup => new AdminAdGroup() { Id = dbAdminAdGroup.Id, Dn = dbAdminAdGroup.Dn });

            AdminUserGroupDetail adminUserGroupDetail = new AdminUserGroupDetail()
            {
                Id = adminUserGroup.Id,
                Name = adminUserGroup.Name,
                Permissions = adminUserGroup.Permissions,
                CalculatedPermissions = calculatedPermissions,
                AdminEmailUserMembers = adminEmailUserMembers,
                AdminUserGroupMembers = adminUserGroupMembers,
                AdminAdUserMembers = adminAdUserMembers,
                AdminAdGroupMembers = adminAdGroupMembers,
                ParentAdminUserGroups = parentAdminUserGroups
            };

            return LogicResult<IAdminUserGroupDetail>.Ok(adminUserGroupDetail);
        }

        public ILogicResult<Guid> CreateAdminUserGroup(string name)
        {
            if (this.adminUserGroupsCrudRepository.DoesAdminUserGroupExist(name))
            {
                this.logger.LogDebug("AdminUserGroup mit diesem Namen existiert bereits.");
                return LogicResult<Guid>.Conflict("AdminUserGroup mit diesem Namen existiert bereits.");
            }

            DbAdminUserGroup adminUserGroupToAdd = this.CreateNewAdminUserGroup(name);

            this.adminUserGroupsCrudRepository.CreateAdminUserGroup(adminUserGroupToAdd);

            this.logger.LogInformation("AdminUserGroup ({name}) angelegt", name);
            return LogicResult<Guid>.Ok(adminUserGroupToAdd.Id);
        }

        public ILogicResult UpdateAdminUserGroup(Guid adminUserGroupId, string name)
        {
            if (this.adminUserGroupsCrudRepository.DoesAdminUserGroupExist(name))
            {
                this.logger.LogDebug("AdminUserGroup mit diesem Namen existiert bereits.");
                return LogicResult.Conflict("AdminUserGroup mit diesem Namen existiert bereits.");
            }

            IDbAdminUserGroup adminUserGroupToUpdate = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);
            if (adminUserGroupToUpdate == null)
            {
                this.logger.LogDebug("AdminUserGroup konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminUserGroup konnte nicht gefunden werden.");
            }

            var nameBefore = adminUserGroupToUpdate.Name;
            adminUserGroupToUpdate.Name = name;
            this.adminUserGroupsCrudRepository.UpdateAdminUserGroup(adminUserGroupToUpdate);

            this.logger.LogInformation("Gruppe ({adminUserGroupnameBefore}) umbenannt zu {adminUserGroupname}", nameBefore, name);
            return LogicResult.Ok();
        }

        public ILogicResult DeleteAdminUserGroup(Guid adminUserGroupId)
        {
            IDbAdminUserGroup adminUserGroupToDelete = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);
            if (adminUserGroupToDelete == null)
            {
                this.logger.LogDebug("AdminUserGroup konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminUserGroup konnte nicht gefunden werden.");
            }

            this.adminUserGroupsCrudRepository.DeleteAdminUserGroup(adminUserGroupToDelete.Id);

            this.adminAccessTokensCrudRepository.DeleteAllAdminAccessTokens();

            this.logger.LogInformation("Gruppe ({name}) gelöscht", adminUserGroupToDelete.Name);
            return LogicResult.Ok();
        }

        public ILogicResult UpdateAdminUserGroupPermissions(Guid adminUserGroupId, IDictionary<string, PermissionStatus> permissionsUpdate)
        {
            IDbAdminUserGroup adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);
            if (adminUserGroup == null)
            {
                this.logger.LogDebug("AdminUserGroup konnte nicht gefunden werden.");
                return LogicResult.NotFound("AdminUserGroup konnte nicht gefunden werden.");
            }

            adminUserGroup.Permissions = permissionsUpdate;
            this.adminUserGroupsCrudRepository.UpdateAdminUserGroup(adminUserGroup);

            this.adminAccessTokensCrudRepository.DeleteAllAdminAccessTokens();

            this.logger.LogInformation("Berechtigungen für Gruppe ({name}) geändert: {permissions}", adminUserGroup.Name, string.Join(";", permissionsUpdate));
            return LogicResult.Ok();
        }

        public ILogicResult AddAdminUserGroupToAdminUserGroup(Guid adminUserGroupId, Guid parentAdminUserGroupId)
        {
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);
            var parentAdminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(parentAdminUserGroupId);

            if (adminUserGroup == null || parentAdminUserGroup == null)
            {
                this.logger.LogDebug("Eine der angegebenen AdminUserGroups konnte nicht gefunden werden.");
                return LogicResult.NotFound("Eine der angegebenen AdminUserGroups konnte nicht gefunden werden.");
            }

            this.adminUserGroupMembershipRepository.AddAdminUserGroupToAdminUserGroup(adminUserGroupId, parentAdminUserGroupId);

            if (this.adminUserGroupMembershipRepository.HasCircularMembership(adminUserGroupId))
            {
                this.adminUserGroupMembershipRepository.RemoveAdminUserGroupFromAdminUserGroup(adminUserGroupId, parentAdminUserGroupId);
                this.logger.LogDebug("Gruppe ({adminUserGroupname}) kann nicht zu Gruppe ({parentAdminUserGroupname}) hinzugefügt werden, aufgrund eines Circular Dependency Errors.", adminUserGroup.Name, parentAdminUserGroup.Name);
                return LogicResult.Conflict("Aufgrund eines Circular Dependency Errors kann die Gruppe nicht hinzugefügt werden.");
            }

            this.adminAccessTokensCrudRepository.DeleteAllAdminAccessTokens();

            this.logger.LogInformation("Gruppe ({adminUserGroupname}) zu Gruppe ({parentAdminUserGroupname}) hinzugefügt", adminUserGroup.Name, parentAdminUserGroup.Name);
            return LogicResult.Ok();
        }

        public ILogicResult RemoveAdminUserGroupFromAdminUserGroup(Guid adminUserGroupId, Guid parentId)
        {
            var adminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(adminUserGroupId);
            var parentAdminUserGroup = this.adminUserGroupsCrudRepository.GetAdminUserGroup(parentId);

            if (adminUserGroup == null || parentAdminUserGroup == null)
            {
                this.logger.LogDebug("Eine der angegebenen AdminUserGroups konnte nicht gefunden werden.");
                return LogicResult.NotFound("Eine der angegebenen AdminUserGroups konnte nicht gefunden werden.");
            }

            this.adminUserGroupMembershipRepository.RemoveAdminUserGroupFromAdminUserGroup(adminUserGroupId, parentId);

            this.adminAccessTokensCrudRepository.DeleteAllAdminAccessTokens();

            this.logger.LogInformation("Gruppe ({adminUserGroupname}) aus Gruppe ({parentAdminUserGroupname}) entfernt", adminUserGroup.Name, parentAdminUserGroup.Name);
            return LogicResult.Ok();
        }

        private DbAdminUserGroup CreateNewAdminUserGroup(string name)
        {
            return new DbAdminUserGroup()
            {
                Id = this.guidGenerator.NewGuid(),
                Name = name,
                Permissions = PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.NOT_SET)
            };
        }
    }
}