using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzuebersicht.Backend.Admin.Core.API.APIConfiguration
{
    public static class CrossOriginResourceSharing
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(cors =>
                cors.AddDefaultPolicy(policy =>
                    policy.WithOrigins(configuration["CorsOrigins"])
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()));
        }
    }
}