using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    [Table("AdminAdGroupAdminUserGroupRelations")]
    public partial class EfAdminAdGroupAdminUserGroupRelation
    {
        public Guid MemberId { get; set; }

        public Guid ParentId { get; set; }

        public virtual EfAdminAdGroup Member { get; set; }

        public virtual EfAdminUserGroup Parent { get; set; }
    }
}