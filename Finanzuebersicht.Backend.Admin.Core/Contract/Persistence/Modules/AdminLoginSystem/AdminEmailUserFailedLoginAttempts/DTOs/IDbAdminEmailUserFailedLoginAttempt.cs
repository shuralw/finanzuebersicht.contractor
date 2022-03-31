using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    public interface IDbAdminEmailUserFailedLoginAttempt
    {
        DateTime OccurredAt { get; set; }

        Guid AdminEmailUserId { get; set; }
    }
}