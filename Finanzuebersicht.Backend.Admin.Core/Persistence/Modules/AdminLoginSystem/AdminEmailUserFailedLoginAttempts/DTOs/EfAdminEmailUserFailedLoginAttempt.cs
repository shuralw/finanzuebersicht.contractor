using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    [Table("AdminEmailUserFailedLoginAttempts")]
    public partial class EfAdminEmailUserFailedLoginAttempt
    {
        public int Id { get; set; }

        public Guid AdminEmailUserId { get; set; }

        public DateTime OccurredAt { get; set; }

        public virtual EfAdminEmailUser AdminEmailUser { get; set; }
    }
}