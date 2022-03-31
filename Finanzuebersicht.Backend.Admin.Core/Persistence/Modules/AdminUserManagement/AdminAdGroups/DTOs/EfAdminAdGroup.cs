using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups
{
    [Table("AdminAdGroups")]
    public partial class EfAdminAdGroup
    {
        public EfAdminAdGroup()
        {
            this.AdminAdGroupAdminUserGroupRelations = new HashSet<EfAdminAdGroupAdminUserGroupRelation>();
        }

        public Guid Id { get; set; }

        public string Dn { get; set; }

        public virtual EfAdminAdGroupPermissionsEntry Permissions { get; set; }

        public virtual ICollection<EfAdminAdGroupAdminUserGroupRelation> AdminAdGroupAdminUserGroupRelations { get; set; }
    }
}