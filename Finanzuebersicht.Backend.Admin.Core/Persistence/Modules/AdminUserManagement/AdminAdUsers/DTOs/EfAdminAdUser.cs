using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers
{
    [Table("AdminAdUsers")]
    public partial class EfAdminAdUser
    {
        public EfAdminAdUser()
        {
            this.AdminAdUserAdminUserGroupRelations = new HashSet<EfAdminAdUserAdminUserGroupRelation>();
        }

        public Guid Id { get; set; }

        public string Dn { get; set; }

        public virtual EfAdminAdUserPermissionsEntry Permissions { get; set; }

        public virtual ICollection<EfAdminAdUserAdminUserGroupRelation> AdminAdUserAdminUserGroupRelations { get; set; }
    }
}