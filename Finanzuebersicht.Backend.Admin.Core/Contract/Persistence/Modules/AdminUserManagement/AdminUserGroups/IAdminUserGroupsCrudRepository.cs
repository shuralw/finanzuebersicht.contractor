using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Tools.Pagination;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    public interface IAdminUserGroupsCrudRepository
    {
        void CreateAdminUserGroup(IDbAdminUserGroup adminUserGroup);

        void DeleteAdminUserGroup(Guid adminUserGroupId);

        bool DoesAdminUserGroupExist(string name);

        IDbAdminUserGroup GetAdminUserGroup(Guid adminUserGroupId);

        IDbPagedResult<IDbAdminUserGroup> GetPagedAdminUserGroups();

        void UpdateAdminUserGroup(IDbAdminUserGroup adminUserGroup);
    }
}