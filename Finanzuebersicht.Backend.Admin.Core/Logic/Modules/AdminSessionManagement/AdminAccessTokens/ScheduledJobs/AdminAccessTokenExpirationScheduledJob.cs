using Microsoft.Extensions.Options;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.JobScheduler;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using System.Threading.Tasks;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens
{
    internal class AdminAccessTokenExpirationScheduledJob : IScheduledJob
    {
        private readonly IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository;

        private readonly IDateTimeProvider dateTimeProvider;

        private readonly AdminAccessTokenOptions sessionExpirationOptions;

        public AdminAccessTokenExpirationScheduledJob(
            IAdminAccessTokensCrudRepository adminAccessTokensCrudRepository,
            IDateTimeProvider dateTimeProvider,
            IOptions<AdminAccessTokenOptions> options)
        {
            this.adminAccessTokensCrudRepository = adminAccessTokensCrudRepository;

            this.dateTimeProvider = dateTimeProvider;

            this.sessionExpirationOptions = options.Value;
        }

        public int GetDelayInSeconds() => this.sessionExpirationOptions.ExpirationTimeInMinutes * 60;

        public bool IsExecutingOnInitialization() => this.sessionExpirationOptions.RunOnInitialization;

        public Task Execute()
        {
            this.adminAccessTokensCrudRepository.DeleteExpiredAdminAccessTokens(this.dateTimeProvider.Now());

            return Task.CompletedTask;
        }
    }
}