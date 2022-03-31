using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.Ad;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminLoginSystem.AdminEmailUser;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.Email;
using Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.FileSystem;
using Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.SsoAuthentication;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Identifier;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Password;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserLogin;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Logic.JobScheduler;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminAdLogin;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.Email;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.FileSystem;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.SsoAuthentication;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Time;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Tools.Identifier;
using System;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.Accounting.CategorySearchTerms;

namespace Finanzuebersicht.Backend.Admin.Core.Logic
{
    public static class DependencyProvider
    {
        public static void Startup(IServiceCollection services, IConfiguration configuration)
        {
            StartupLogin(services, configuration);
            StartupSessions(services, configuration);
            StartupAdminUserManagement(services, configuration);
            StartupSystemConnections(services, configuration);
            StartupTools(services);
            StartupAccounting(services);
        }

        private static void StartupAccounting(IServiceCollection services)
        {
            // AccountingEntries
            services.AddScoped<IAccountingEntriesCrudLogic, AccountingEntriesCrudLogic>();

            // Categories
            services.AddScoped<ICategoriesCrudLogic, CategoriesCrudLogic>();

            // CategorySearchTerms
            services.AddScoped<ICategorySearchTermsCrudLogic, CategorySearchTermsCrudLogic>();
            services.AddScoped<ISaldenLogic, SaldenLogic>();
            services.AddScoped<ICategoryIdentifyingLogic, CategoryIdentifyingLogic>();
        }

        private static void StartupLogin(IServiceCollection services, IConfiguration configuration)
        {
            // AdminEmailUser-Login
            services.AddScoped<IAdminEmailUserLoginLogic, AdminEmailUserLoginLogic>();
            services.AddScoped<IAdminEmailUserFailedLoginAttemptsLogic, AdminEmailUserFailedLoginAttemptsLogic>();
            services.AddScheduledJob<AdminEmailUserFailedLoginAttemptsExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<AdminEmailUserFailedLoginAttemptsOptions>(configuration);

            // AD-Login
            services.AddScoped<IAdminAdLoginLogic, AdminAdLoginLogic>();
        }

        private static void StartupSessions(IServiceCollection services, IConfiguration configuration)
        {
            // AdminAccessTokens
            services.AddScoped<IAdminAccessTokensCrudLogic, AdminAccessTokensCrudLogic>();
            services.AddScheduledJob<AdminAccessTokenExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<AdminAccessTokenOptions>(configuration);

            // AdminRefreshTokens
            services.AddScoped<IAdminRefreshTokensCrudLogic, AdminRefreshTokensCrudLogic>();
            services.AddScheduledJob<AdminRefreshTokenExpirationScheduledJob>();
            services.AddOptionsFromConfiguration<AdminRefreshTokenOptions>(configuration);
        }

        private static void StartupAdminUserManagement(IServiceCollection services, IConfiguration configuration)
        {
            // AdminEmailUsers
            services.AddScoped<IAdminEmailUsersCrudLogic, AdminEmailUsersCrudLogic>();
            services.AddScoped<IAdminEmailUserPasswordChangeLogic, AdminEmailUserPasswordChangeLogic>();
            services.AddScoped<IAdminEmailUserPasswordResetLogic, AdminEmailUserPasswordResetLogic>();
            services.AddOptionsFromConfiguration<AdminEmailUserPasswordResetOptions>(configuration);
            services.AddScheduledJob<AdminEmailUserPasswordResetExpirationScheduledJob>();
            services.AddSingleton<IAdminEmailUserPasswordResetMailLogic, AdminEmailUserPasswordResetMailLogic>();

            // AdminUserGroups
            services.AddScoped<IAdminUserGroupsCrudLogic, AdminUserGroupsCrudLogic>();

            // AdminAdUsers
            services.AddScoped<IAdminAdUsersCrudLogic, AdminAdUsersCrudLogic>();

            // AdminAdGroups
            services.AddScoped<IAdminAdGroupsCrudLogic, AdminAdGroupsCrudLogic>();

            // Permissions
            services.AddScoped<IAdminEmailUserPermissionsCalculationLogic, AdminEmailUserPermissionsCalculationLogic>();
            services.AddScoped<IAdminUserGroupPermissionsCalculationLogic, AdminUserGroupPermissionsCalculationLogic>();
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