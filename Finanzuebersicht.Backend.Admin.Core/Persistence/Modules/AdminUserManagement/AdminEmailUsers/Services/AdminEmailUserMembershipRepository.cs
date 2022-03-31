using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    internal class AdminEmailUserMembershipRepository : IAdminEmailUserMembershipRepository
    {
        private readonly PersistenceDbContext context;

        public AdminEmailUserMembershipRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public void AddAdminEmailUserToAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId)
        {
            this.context.AdminEmailUserAdminUserGroupRelations.Add(new EfAdminEmailUserAdminUserGroupRelation()
            {
                MemberId = adminEmailUserId,
                ParentId = adminUserGroupId
            });
            this.context.SaveChanges();
        }

        public IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminEmailUser(Guid adminEmailUserId)
        {
            return this.context.AdminEmailUserAdminUserGroupRelations
                .Include(relation => relation.Parent)
                    .ThenInclude(adminUserGroup => adminUserGroup.Permissions)
                .Where(relation => relation.MemberId == adminEmailUserId)
                .OrderBy(relation => relation.Parent.Name)
                .Select(relation => DbAdminUserGroup.FromEfAdminUserGroup(relation.Parent));
        }

        public void RemoveAdminEmailUserFromAdminUserGroup(Guid adminEmailUserId, Guid adminUserGroupId)
        {
            var relationToDelete = this.context.AdminEmailUserAdminUserGroupRelations
                .Where(relation => relation.MemberId == adminEmailUserId && relation.ParentId == adminUserGroupId)
                .FirstOrDefault();
            this.context.AdminEmailUserAdminUserGroupRelations.Remove(relationToDelete);
            this.context.SaveChanges();
        }
    }
}