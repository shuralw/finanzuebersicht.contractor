using Microsoft.Extensions.DependencyInjection;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.JobScheduler;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.JobScheduler
{
    public static class ScheduledJobExtension
    {
        public static IServiceCollection AddScheduledJob<TScheduledJob>(this IServiceCollection services)
            where TScheduledJob : IScheduledJob
        {
            services.AddScoped(typeof(TScheduledJob));
            services.AddHostedService<JobScheduler<TScheduledJob>>();

            return services;
        }
    }
}