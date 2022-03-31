using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    public partial class DbAdminEmailUserFailedLoginAttempt : IDbAdminEmailUserFailedLoginAttempt
    {
        public Guid AdminEmailUserId { get; set; }

        public DateTime OccurredAt { get; set; }

        public static DbAdminEmailUserFailedLoginAttempt FromEfAdminEmailUserFailedLoginAttempt(EfAdminEmailUserFailedLoginAttempt efAdminEmailUserFailedLoginAttempt)
        {
            if (efAdminEmailUserFailedLoginAttempt == null)
            {
                return null;
            }

            return new DbAdminEmailUserFailedLoginAttempt()
            {
                AdminEmailUserId = efAdminEmailUserFailedLoginAttempt.AdminEmailUserId,
                OccurredAt = efAdminEmailUserFailedLoginAttempt.OccurredAt
            };
        }

        public static EfAdminEmailUserFailedLoginAttempt ToEfAdminEmailUserFailedLoginAttempt(IDbAdminEmailUserFailedLoginAttempt adminEmailUserFailedLoginAttempt)
        {
            return new EfAdminEmailUserFailedLoginAttempt()
            {
                AdminEmailUserId = adminEmailUserFailedLoginAttempt.AdminEmailUserId,
                OccurredAt = adminEmailUserFailedLoginAttempt.OccurredAt
            };
        }
    }
}