using Microsoft.EntityFrameworkCore;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    internal class AdminUserGroupMembershipRepository : IAdminUserGroupMembershipRepository
    {
        private readonly PersistenceDbContext context;

        public AdminUserGroupMembershipRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public void AddAdminUserGroupToAdminUserGroup(Guid adminUserGroupId, Guid parentId)
        {
            this.context.AdminUserGroupAdminUserGroupRelations.Add(new EfAdminUserGroupAdminUserGroupRelation()
            {
                MemberId = adminUserGroupId,
                ParentId = parentId
            });
            this.context.SaveChanges();
        }

        public bool HasCircularMembership(Guid adminUserGroupId)
        {
            return this.FindCircular(adminUserGroupId, adminUserGroupId);
        }

        public IEnumerable<IDbAdminAdGroup> GetAdminAdGroupsOfAdminUserGroup(Guid adminUserGroupId)
        {
            return this.context.AdminAdGroupAdminUserGroupRelations
                .Include(relation => relation.Member)
                    .ThenInclude(adminAdGroup => adminAdGroup.Permissions)
                .Where(relation => relation.ParentId == adminUserGroupId)
                .OrderBy(relation => relation.Member.Dn)
                .Select(relation => DbAdminAdGroup.FromEfAdminAdGroup(relation.Member));
        }

        public IEnumerable<IDbAdminAdUser> GetAdminAdUsersOfAdminUserGroup(Guid adminUserGroupId)
        {
            return this.context.AdminAdUserAdminUserGroupRelations
                .Include(relation => relation.Member)
                    .ThenInclude(adminAdGroup => adminAdGroup.Permissions)
                .Where(relation => relation.ParentId == adminUserGroupId)
                .OrderBy(relation => relation.Member.Dn)
                .Select(relation => DbAdminAdUser.FromEfAdminAdUser(relation.Member));
        }

        public IEnumerable<IDbAdminUserGroup> GetAdminUserGroupParentsOfAdminUserGroup(Guid adminUserGroupId)
        {
            return this.context.AdminUserGroupAdminUserGroupRelations
                .Include(relation => relation.Parent)
                    .ThenInclude(adminUserGroup => adminUserGroup.Permissions)
                .Where(relation => relation.MemberId == adminUserGroupId)
                .OrderBy(relation => relation.Parent.Name)
                .Select(relation => DbAdminUserGroup.FromEfAdminUserGroup(relation.Parent));
        }

        public IEnumerable<IDbAdminUserGroup> GetAdminUserGroupsOfAdminUserGroup(Guid adminUserGroupId)
        {
            return this.context.AdminUserGroupAdminUserGroupRelations
                .Include(relation => relation.Member)
                    .ThenInclude(adminUserGroup => adminUserGroup.Permissions)
                .Where(relation => relation.ParentId == adminUserGroupId)
                .OrderBy(relation => relation.Member.Name)
                .Select(relation => DbAdminUserGroup.FromEfAdminUserGroup(relation.Member));
        }

        public IEnumerable<IDbAdminEmailUser> GetAdminEmailUsersOfAdminUserGroup(Guid adminUserGroupId)
        {
            return this.context.AdminEmailUserAdminUserGroupRelations
                .Include(relation => relation.Member)
                    .ThenInclude(adminEmailUser => adminEmailUser.Permissions)
                .Where(relation => relation.ParentId == adminUserGroupId)
                .OrderBy(relation => relation.Member.Email)
                .Select(relation => DbAdminEmailUser.FromEfAdminEmailUser(relation.Member));
        }

        public void RemoveAdminUserGroupFromAdminUserGroup(Guid adminUserGroupId, Guid parentId)
        {
            var relationToDelete = this.context.AdminUserGroupAdminUserGroupRelations
                .Where(relation => relation.MemberId == adminUserGroupId && relation.ParentId == parentId)
                .FirstOrDefault();
            this.context.AdminUserGroupAdminUserGroupRelations.Remove(relationToDelete);
            this.context.SaveChanges();
        }

        private bool FindCircular(Guid currentAdminUserGroupId, Guid rootAdminUserGroupId)
        {
            var parentIdsOfCurrentAdminUserGroup = this.context.AdminUserGroupAdminUserGroupRelations
                .Where(relation => relation.MemberId == currentAdminUserGroupId)
                .Select(relation => relation.ParentId)
                .ToList();

            foreach (var parentId in parentIdsOfCurrentAdminUserGroup)
            {
                if (parentId == rootAdminUserGroupId || this.FindCircular(parentId, rootAdminUserGroupId))
                {
                    return true;
                }
            }

            return false;
        }
    }
}