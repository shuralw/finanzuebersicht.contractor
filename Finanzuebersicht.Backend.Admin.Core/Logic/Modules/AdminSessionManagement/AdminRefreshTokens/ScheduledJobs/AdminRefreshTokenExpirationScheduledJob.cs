using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.JobScheduler;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens
{
    internal class AdminRefreshTokenExpirationScheduledJob : IScheduledJob
    {
        private readonly IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly AdminRefreshTokenOptions sessionExpirationOptions;

        public AdminRefreshTokenExpirationScheduledJob(
            IAdminRefreshTokensCrudRepository adminRefreshTokensCrudRepository,
            IDateTimeProvider dateTimeProvider,
            IOptions<AdminRefreshTokenOptions> options)
        {
            this.adminRefreshTokensCrudRepository = adminRefreshTokensCrudRepository;

            this.dateTimeProvider = dateTimeProvider;

            this.sessionExpirationOptions = options.Value;
        }

        public int GetDelayInSeconds() => this.sessionExpirationOptions.ExpirationTimeInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.sessionExpirationOptions.RunOnInitialization;

        public Task Execute()
        {
            this.adminRefreshTokensCrudRepository.DeleteExpiredAdminRefreshTokens(this.dateTimeProvider.Now());

            return Task.CompletedTask;
        }
    }
}