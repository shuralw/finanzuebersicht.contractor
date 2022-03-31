using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    internal class AdminEmailUserFailedLoginAttemptsCrudRepository : IAdminEmailUserFailedLoginAttemptsCrudRepository
    {
        private readonly PersistenceDbContext context;

        public AdminEmailUserFailedLoginAttemptsCrudRepository(PersistenceDbContext context)
        {
            this.context = context;
        }

        public List<IDbAdminEmailUserFailedLoginAttempt> GetFailedLoginAttempts(Guid adminEmailUserId)
        {
            return this.context.AdminEmailUserFailedLoginAttempts
                .Where(attempt => attempt.AdminEmailUserId == adminEmailUserId)
                .Select(attempt => DbAdminEmailUserFailedLoginAttempt.FromEfAdminEmailUserFailedLoginAttempt(attempt))
                .ToList<IDbAdminEmailUserFailedLoginAttempt>();
        }

        public void CreateFailedLoginAttempt(IDbAdminEmailUserFailedLoginAttempt adminEmailUserFailedLoginAttempt)
        {
            EfAdminEmailUserFailedLoginAttempt efAdminEmailUserFailedLoginAttempt =
                DbAdminEmailUserFailedLoginAttempt.ToEfAdminEmailUserFailedLoginAttempt(adminEmailUserFailedLoginAttempt);

            this.context.AdminEmailUserFailedLoginAttempts.Add(efAdminEmailUserFailedLoginAttempt);

            this.context.SaveChanges();
        }

        public void DeleteFailedLoginAttempts(Guid adminEmailUserId)
        {
            var attemptsToDelete = this.context.AdminEmailUserFailedLoginAttempts
                .Where(attempt => attempt.AdminEmailUserId == adminEmailUserId);

            this.context.AdminEmailUserFailedLoginAttempts.RemoveRange(attemptsToDelete);
            this.context.SaveChanges();
        }

        public void DeleteFailedLoginAttempts(DateTime olderThan)
        {
            var attemptsToDelete = this.context.AdminEmailUserFailedLoginAttempts
                .Where(attempt => attempt.OccurredAt < olderThan);

            this.context.AdminEmailUserFailedLoginAttempts.RemoveRange(attemptsToDelete);
            this.context.SaveChanges();
        }
    }
}