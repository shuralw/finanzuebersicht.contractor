using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    [Table("AdminEmailUserAdminUserGroupRelations")]
    public partial class EfAdminEmailUserAdminUserGroupRelation
    {
        public Guid MemberId { get; set; }

        public Guid ParentId { get; set; }

        public virtual EfAdminEmailUser Member { get; set; }

        public virtual EfAdminUserGroup Parent { get; set; }
    }
}