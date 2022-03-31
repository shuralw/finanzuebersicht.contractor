using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.LoginSystem.Ad;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.LoginSystem.EmailUser;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.LoginSystem.MandantLoginAsGlobalAdmin;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.UserManagement.EmailUserPasswordReset;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.UserManagement.Permissions;
using SchuelerOnline.Backend.Generated.Contract.Logic.Modules.UserManagement.UserGroups;
using SchuelerOnline.Backend.Generated.Contract.Logic.SystemConnections.Email;
using SchuelerOnline.Backend.Generated.Contract.Logic.SystemConnections.FileSystem;
using SchuelerOnline.Backend.Generated.Contract.Logic.SystemConnections.SsoAuthentication;
using SchuelerOnline.Backend.Generated.Contract.Logic.Tools.Identifier;
using SchuelerOnline.Backend.Generated.Contract.Logic.Tools.Password;
using SchuelerOnline.Backend.Generated.Contract.Logic.Tools.Time;
using SchuelerOnline.Backend.Generated.Logic.JobScheduler;
using SchuelerOnline.Backend.Generated.Logic.Modules.LoginSystem.AdLogin;
using SchuelerOnline.Backend.Generated.Logic.Modules.LoginSystem.EmailUserFailedLoginAttempts;
using SchuelerOnline.Backend.Generated.Logic.Modules.LoginSystem.EmailUserLogin;
using SchuelerOnline.Backend.Generated.Logic.Modules.LoginSystem.MandantLoginAsGlobalAdmin;
using SchuelerOnline.Backend.Generated.Logic.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Logic.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Logic.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Logic.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Logic.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Logic.Modules.UserManagement.EmailUserPasswordReset;
using SchuelerOnline.Backend.Generated.Logic.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Logic.Modules.UserManagement.Permissions;
using SchuelerOnline.Backend.Generated.Logic.Modules.UserManagement.UserGroups;
using SchuelerOnline.Backend.Generated.Logic.SystemConnections.Email;
using SchuelerOnline.Backend.Generated.Logic.SystemConnections.FileSystem;
using SchuelerOnline.Backend.Generated.Logic.SystemConnections.SsoAuthentication;
using SchuelerOnline.Backend.Generated.Logic.Tools.Identifier;
using SchuelerOnline.Backend.Generated.Logic.Tools.Password;
using SchuelerOnline.Backend.Generated.Logic.Tools.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SchuelerOnline.Backend.Generated.Logic
{
    public static class DependencyProvider
    {
        public static void Startup(IServiceCollection services, IConfiguration configuration)
        {
            StartupLogin(services, configuration);
            StartupMandanten(services);
            StartupSessions(services, configuration);
            StartupUserManagement(services, configuration);
            StartupSystemConnections(services, configuration);
            StartupTools(services);
        }

        private static void StartupLogin(IServiceCollection services, IConfiguration configuration)
        {
            // EmailUser-Login
            services.AddScoped<IEmailUserLoginLogic, EmailUserLoginLogic>();
            services.AddScoped<IEmailUserFailedLoginAttemptsLogic, EmailUserFailedLoginAttemptsLogic>();
            services.AddScheduledJob<EmailUserFailedLoginAttemptsExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<EmailUserFailedLoginAttemptsOptions>(configuration);

            // AD-Login
            services.AddScoped<IAdLoginLogic, AdLoginLogic>();

            // Mandant-Login
            services.AddScoped<IMandantLoginAsGlobalAdminLogic, MandantLoginAsGlobalAdminLogic>();
        }

        private static void StartupMandanten(IServiceCollection services)
        {
            services.AddScoped<IMandantenCrudLogic, MandantenCrudLogic>();
        }

        private static void StartupSessions(IServiceCollection services, IConfiguration configuration)
        {
            // AccessTokens
            services.AddScoped<IAccessTokensCrudLogic, AccessTokensCrudLogic>();
            services.AddScheduledJob<AccessTokenExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<AccessTokenOptions>(configuration);

            // RefreshTokens
            services.AddScoped<IRefreshTokensCrudLogic, RefreshTokensCrudLogic>();
            services.AddScheduledJob<RefreshTokenExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<RefreshTokenOptions>(configuration);
        }

        private static void StartupUserManagement(IServiceCollection services, IConfiguration configuration)
        {
            // EmailUsers
            services.AddScoped<IEmailUsersCrudLogic, EmailUsersCrudLogic>();
            services.AddScoped<IEmailUserPasswordChangeLogic, EmailUserPasswordChangeLogic>();
            services.AddScoped<IEmailUserPasswordResetLogic, EmailUserPasswordResetLogic>();
            services.AddOptionsFromConfiguration<EmailUserPasswordResetOptions>(configuration);
            services.AddScheduledJob<EmailUserPasswordResetExpirationScheduledJob>();
            services.AddSingleton<IEmailUserPasswordResetMailLogic, EmailUserPasswordResetMailLogic>();

            // UserGroups
            services.AddScoped<IUserGroupsCrudLogic, UserGroupsCrudLogic>();

            // AdUsers
            services.AddScoped<IAdUsersCrudLogic, AdUsersCrudLogic>();

            // AdGroups
            services.AddScoped<IAdGroupsCrudLogic, AdGroupsCrudLogic>();

            // Permissions
            services.AddScoped<IEmailUserPermissionsCalculationLogic, EmailUserPermissionsCalculationLogic>();
            services.AddScoped<IUserGroupPermissionsCalculationLogic, UserGroupPermissionsCalculationLogic>();
            services.AddScoped<IAdPermissionsCalculationLogic, AdPermissionsCalculationLogic>();
        }

        private static void StartupSystemConnections(IServiceCollection services, IConfiguration configuration)
        {
            // E-Mail
            services.AddSingleton<IEmailClient, EmailClient>();
            services.AddOptionsFromConfiguration<EmailClientOptions>(configuration);

            // File System
            services.AddSingleton<IFileSystemClient, FileSystemClient>();

            // SsoAuthentication
            services.AddSingleton<ISsoAuthenticationClient, SsoAuthenticationClient>();
            services.AddOptionsFromConfiguration<SsoAuthenticationOptions>(configuration);
        }

        private static void StartupTools(IServiceCollection services)
        {
            // BSI Passwort
            services.AddSingleton<IBsiPasswordHasher, BsiPasswordHasher>();

            // DateTime
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // Guid
            services.AddSingleton<IGuidGenerator, GuidGenerator>();

            // SHA256 Token
            services.AddSingleton<ISHA256TokenGenerator, SHA256TokenGenerator>();
        }
    }
}