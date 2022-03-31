using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    [Table("AdminEmailUsers")]
    public partial class EfAdminEmailUser
    {
        public EfAdminEmailUser()
        {
            this.AdminEmailUserFailedLoginAttempts = new HashSet<EfAdminEmailUserFailedLoginAttempt>();
            this.AdminEmailUserAdminUserGroupRelations = new HashSet<EfAdminEmailUserAdminUserGroupRelation>();
            this.AdminEmailUserPasswordResetTokens = new HashSet<EfAdminEmailUserPasswordResetToken>();
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public virtual EfAdminEmailUserPermissionsEntry Permissions { get; set; }

        public virtual ICollection<EfAdminEmailUserFailedLoginAttempt> AdminEmailUserFailedLoginAttempts { get; set; }

        public virtual ICollection<EfAdminEmailUserAdminUserGroupRelation> AdminEmailUserAdminUserGroupRelations { get; set; }

        public virtual ICollection<EfAdminEmailUserPasswordResetToken> AdminEmailUserPasswordResetTokens { get; set; }
    }
}