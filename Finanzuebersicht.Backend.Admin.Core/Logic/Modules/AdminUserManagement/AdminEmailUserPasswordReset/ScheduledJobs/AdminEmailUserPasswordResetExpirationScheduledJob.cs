using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.JobScheduler;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset
{
    internal class AdminEmailUserPasswordResetExpirationScheduledJob : IScheduledJob
    {
        private readonly IAdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly AdminEmailUserPasswordResetOptions options;

        public AdminEmailUserPasswordResetExpirationScheduledJob(
            IAdminEmailUserPasswordResetTokenRepository adminEmailUserPasswordResetTokenRepository,
            IDateTimeProvider dateTimeProvider,
            IOptions<AdminEmailUserPasswordResetOptions> options)
        {
            this.adminEmailUserPasswordResetTokenRepository = adminEmailUserPasswordResetTokenRepository;

            this.dateTimeProvider = dateTimeProvider;

            this.options = options.Value;
        }

        public int GetDelayInSeconds() => this.options.ExpirationTimeInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.options.RunOnInitialization;

        public Task Execute()
        {
            this.adminEmailUserPasswordResetTokenRepository.DeleteToken(this.dateTimeProvider.Now());

            return Task.CompletedTask;
        }
    }
}