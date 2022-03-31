using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    [Table("AdminUserGroupAdminUserGroupRelations")]
    public partial class EfAdminUserGroupAdminUserGroupRelation
    {
        public Guid MemberId { get; set; }

        public Guid ParentId { get; set; }

        public virtual EfAdminUserGroup Member { get; set; }

        public virtual EfAdminUserGroup Parent { get; set; }
    }
}