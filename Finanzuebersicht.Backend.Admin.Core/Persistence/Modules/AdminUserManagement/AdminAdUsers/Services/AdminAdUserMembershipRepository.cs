using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    internal class AdminAdUserMembershipRepository : IAdminAdUserMembershipRepository
    {
        private readonly PersistenceDbContext context;

        public AdminAdUserMembershipRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public void AddAdminAdUserToAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId)
        {
            this.context.AdminAdUserAdminUserGroupRelations.Add(new EfAdminAdUserAdminUserGroupRelation()
            {
                MemberId = adminAdUserId,
                ParentId = adminUserGroupId
            });
            this.context.SaveChanges();
        }

        public IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminAdUser(Guid adminAdUserId)
        {
            return this.context.AdminAdUserAdminUserGroupRelations
                .Include(relation => relation.Parent)
                    .ThenInclude(adminAdUser => adminAdUser.Permissions)
                .Where(relation => relation.MemberId == adminAdUserId)
                .OrderBy(relation => relation.Parent.Name)
                .Select(relation => DbAdminUserGroup.FromEfAdminUserGroup(relation.Parent));
        }

        public void RemoveAdminAdUserFromAdminUserGroup(Guid adminAdUserId, Guid adminUserGroupId)
        {
            var relationToDelete = this.context.AdminAdUserAdminUserGroupRelations
                .Where(relation => relation.MemberId == adminAdUserId && relation.ParentId == adminUserGroupId)
                .FirstOrDefault();
            this.context.AdminAdUserAdminUserGroupRelations.Remove(relationToDelete);
            this.context.SaveChanges();
        }
    }
}