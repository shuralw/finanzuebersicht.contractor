using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    [Table("AdminAdUserAdminUserGroupRelations")]
    public partial class EfAdminAdUserAdminUserGroupRelation
    {
        public Guid MemberId { get; set; }

        public Guid ParentId { get; set; }

        public virtual EfAdminAdUser Member { get; set; }

        public virtual EfAdminUserGroup Parent { get; set; }
    }
}