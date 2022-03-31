using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    internal class AdminEmailUserFailedLoginAttemptsLogic : IAdminEmailUserFailedLoginAttemptsLogic
    {
        private readonly IAdminEmailUserFailedLoginAttemptsCrudRepository adminEmailUserFailedLoginAttemptsCrudRepository;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly AdminEmailUserFailedLoginAttemptsOptions options;

        public AdminEmailUserFailedLoginAttemptsLogic(
            IAdminEmailUserFailedLoginAttemptsCrudRepository adminEmailUserFailedLoginAttemptsCrudRepository,
            IDateTimeProvider dateTimeProvider,
            IOptions<AdminEmailUserFailedLoginAttemptsOptions> options)
        {
            this.adminEmailUserFailedLoginAttemptsCrudRepository = adminEmailUserFailedLoginAttemptsCrudRepository;

            this.dateTimeProvider = dateTimeProvider;

            this.options = options.Value;
        }

        public bool HasAdminEmailUserTooManyFailedLoginAttempts(Guid adminEmailUserId)
        {
            IEnumerable<IDbAdminEmailUserFailedLoginAttempt> failedLoginAttempts = this.adminEmailUserFailedLoginAttemptsCrudRepository
                .GetFailedLoginAttempts(adminEmailUserId)
                .Where(attempt => attempt.OccurredAt >= this.CalculateThreshold());

            return failedLoginAttempts.Count() >= this.options.MaxCount;
        }

        public void AddFailedLoginAttempt(Guid adminEmailUserId)
        {
            this.adminEmailUserFailedLoginAttemptsCrudRepository.CreateFailedLoginAttempt(new DbAdminEmailUserFailedLoginAttempt()
            {
                AdminEmailUserId = adminEmailUserId,
                OccurredAt = this.dateTimeProvider.Now()
            });
        }

        public void RemoveFailedLoginAttempts(Guid adminEmailUserId)
        {
            this.adminEmailUserFailedLoginAttemptsCrudRepository.DeleteFailedLoginAttempts(adminEmailUserId);
        }

        public void RemoveExpiredFailedLoginAttempts()
        {
            this.adminEmailUserFailedLoginAttemptsCrudRepository.DeleteFailedLoginAttempts(this.CalculateThreshold());
        }

        private DateTime CalculateThreshold()
        {
            return this.dateTimeProvider.Now().AddMinutes(-this.options.ThresholdInMinutes);
        }
    }
}