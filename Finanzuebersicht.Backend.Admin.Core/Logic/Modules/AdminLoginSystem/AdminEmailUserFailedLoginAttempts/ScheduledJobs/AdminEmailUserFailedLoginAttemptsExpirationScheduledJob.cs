using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.JobScheduler;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    internal class AdminEmailUserFailedLoginAttemptsExpirationScheduledJob : IScheduledJob
    {
        private readonly IAdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic;

        private readonly AdminEmailUserFailedLoginAttemptsOptions options;

        public AdminEmailUserFailedLoginAttemptsExpirationScheduledJob(
            IAdminEmailUserFailedLoginAttemptsLogic adminEmailUserFailedLoginAttemptsLogic,
            IOptions<AdminEmailUserFailedLoginAttemptsOptions> options)
        {
            this.adminEmailUserFailedLoginAttemptsLogic = adminEmailUserFailedLoginAttemptsLogic;

            this.options = options.Value;
        }

        public int GetDelayInSeconds() => this.options.ThresholdInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.options.RunOnInitialization;

        public Task Execute()
        {
            this.adminEmailUserFailedLoginAttemptsLogic.RemoveExpiredFailedLoginAttempts();

            return Task.CompletedTask;
        }
    }
}