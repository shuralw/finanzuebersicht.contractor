using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.LoginSystem.EmailUserFailedLoginAttempts;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.UserManagement.EmailUserPasswordResetTokens;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Contract.Persistence.Modules.UserManagement.UserGroups;
using SchuelerOnline.Backend.Generated.Persistence.Modules.LoginSystem.EmailUserFailedLoginAttempts;
using SchuelerOnline.Backend.Generated.Persistence.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Persistence.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Persistence.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.EmailUserPasswordReset;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.UserGroups;
using Microsoft.Extensions.DependencyInjection;

namespace SchuelerOnline.Backend.Generated.Persistence
{
    public static class DependencyProvider
    {
        public static void Startup(IServiceCollection services)
        {
            services.AddHealthChecks().AddDbContextCheck<PersistenceDbContext>();
            services.AddDbContext<PersistenceDbContext>();

            StartupLogin(services);
            StartupMandanten(services);
            StartupUserManagement(services);
            StartupSessions(services);
        }

        private static void StartupLogin(IServiceCollection services)
        {
            services.AddScoped<IEmailUserFailedLoginAttemptsCrudRepository, EmailUserFailedLoginAttemptsCrudRepository>();
        }

        private static void StartupMandanten(IServiceCollection services)
        {
            services.AddScoped<IMandantenCrudRepository, MandantenCrudRepository>();
        }

        private static void StartupSessions(IServiceCollection services)
        {
            services.AddScoped<IAccessTokensCrudRepository, AccessTokensCrudRepository>();
            services.AddScoped<IRefreshTokensCrudRepository, RefreshTokensCrudRepository>();
        }

        private static void StartupUserManagement(IServiceCollection services)
        {
            services.AddScoped<IAdGroupMembershipRepository, AdGroupMembershipRepository>();
            services.AddScoped<IAdGroupsCrudRepository, AdGroupsCrudRepository>();
            services.AddScoped<IAdUserMembershipRepository, AdUserMembershipRepository>();
            services.AddScoped<IAdUsersCrudRepository, AdUsersCrudRepository>();
            services.AddScoped<IEmailUserMembershipRepository, EmailUserMembershipRepository>();
            services.AddScoped<IEmailUserPasswordResetTokenRepository, EmailUserPasswordResetTokenRepository>();
            services.AddScoped<IEmailUsersCrudRepository, EmailUsersCrudRepository>();
            services.AddScoped<IUserGroupMembershipRepository, UserGroupMembershipRepository>();
            services.AddScoped<IUserGroupsCrudRepository, UserGroupsCrudRepository>();
        }
    }
}