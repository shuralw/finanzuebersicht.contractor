using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    [Table("AdminEmailUserPasswordResetTokens")]
    public partial class EfAdminEmailUserPasswordResetToken
    {
        public string Token { get; set; }

        public Guid AdminEmailUserId { get; set; }

        public DateTime ExpiresOn { get; set; }

        public virtual EfAdminEmailUser AdminEmailUser { get; set; }
    }
}