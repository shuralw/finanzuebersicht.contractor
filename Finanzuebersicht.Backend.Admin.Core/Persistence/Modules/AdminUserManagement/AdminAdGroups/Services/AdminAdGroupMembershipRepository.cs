using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    internal class AdminAdGroupMembershipRepository : IAdminAdGroupMembershipRepository
    {
        private readonly PersistenceDbContext context;

        public AdminAdGroupMembershipRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public void AddAdminAdGroupToAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId)
        {
            this.context.AdminAdGroupAdminUserGroupRelations.Add(new EfAdminAdGroupAdminUserGroupRelation()
            {
                MemberId = adminAdGroupId,
                ParentId = adminUserGroupId
            });
            this.context.SaveChanges();
        }

        public IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminAdGroup(Guid adminAdGroupId)
        {
            return this.context.AdminAdGroupAdminUserGroupRelations
                .Include(relation => relation.Parent)
                    .ThenInclude(adminAdGroup => adminAdGroup.Permissions)
                .Where(relation => relation.MemberId == adminAdGroupId)
                .OrderBy(relation => relation.Parent.Name)
                .Select(relation => DbAdminUserGroup.FromEfAdminUserGroup(relation.Parent));
        }

        public void RemoveAdminAdGroupFromAdminUserGroup(Guid adminAdGroupId, Guid adminUserGroupId)
        {
            var relationToDelete = this.context.AdminAdGroupAdminUserGroupRelations
                .Where(relation => relation.MemberId == adminAdGroupId && relation.ParentId == adminUserGroupId)
                .FirstOrDefault();
            this.context.AdminAdGroupAdminUserGroupRelations.Remove(relationToDelete);
            this.context.SaveChanges();
        }
    }
}