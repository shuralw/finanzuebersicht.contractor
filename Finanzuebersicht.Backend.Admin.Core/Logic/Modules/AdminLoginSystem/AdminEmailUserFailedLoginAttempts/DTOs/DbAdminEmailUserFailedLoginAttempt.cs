using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    public partial class DbAdminEmailUserFailedLoginAttempt : IDbAdminEmailUserFailedLoginAttempt
    {
        public Guid AdminEmailUserId { get; set; }

        public DateTime OccurredAt { get; set; }
    }
}