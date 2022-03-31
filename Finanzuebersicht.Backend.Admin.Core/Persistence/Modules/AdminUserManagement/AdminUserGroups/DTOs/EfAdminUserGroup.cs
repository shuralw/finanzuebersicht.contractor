using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups
{
    [Table("AdminUserGroups")]
    public partial class EfAdminUserGroup
    {
        public EfAdminUserGroup()
        {
            this.AdminAdGroupAdminUserGroupRelations = new HashSet<EfAdminAdGroupAdminUserGroupRelation>();
            this.AdminAdUserAdminUserGroupRelations = new HashSet<EfAdminAdUserAdminUserGroupRelation>();
            this.AdminUserGroupAdminUserGroupRelationsMember = new HashSet<EfAdminUserGroupAdminUserGroupRelation>();
            this.AdminUserGroupAdminUserGroupRelationsParent = new HashSet<EfAdminUserGroupAdminUserGroupRelation>();
            this.AdminEmailUserAdminUserGroupRelations = new HashSet<EfAdminEmailUserAdminUserGroupRelation>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual EfAdminUserGroupPermissionsEntry Permissions { get; set; }

        public virtual ICollection<EfAdminAdGroupAdminUserGroupRelation> AdminAdGroupAdminUserGroupRelations { get; set; }

        public virtual ICollection<EfAdminAdUserAdminUserGroupRelation> AdminAdUserAdminUserGroupRelations { get; set; }

        public virtual ICollection<EfAdminUserGroupAdminUserGroupRelation> AdminUserGroupAdminUserGroupRelationsMember { get; set; }

        public virtual ICollection<EfAdminUserGroupAdminUserGroupRelation> AdminUserGroupAdminUserGroupRelationsParent { get; set; }

        public virtual ICollection<EfAdminEmailUserAdminUserGroupRelation> AdminEmailUserAdminUserGroupRelations { get; set; }
    }
}