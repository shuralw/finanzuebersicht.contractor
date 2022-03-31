using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    public interface IAdminEmailUserFailedLoginAttemptsCrudRepository
    {
        void CreateFailedLoginAttempt(IDbAdminEmailUserFailedLoginAttempt adminEmailUserFailedLoginAttempt);

        void DeleteFailedLoginAttempts(DateTime olderThan);

        void DeleteFailedLoginAttempts(Guid adminEmailUserId);

        List<IDbAdminEmailUserFailedLoginAttempt> GetFailedLoginAttempts(Guid adminEmailUserId);
    }
}