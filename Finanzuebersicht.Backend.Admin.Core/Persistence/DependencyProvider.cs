using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Contract.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence
{
    public static class DependencyProvider
    {
        public static void Startup(IServiceCollection services)
        {
            services.AddHealthChecks().AddDbContextCheck<PersistenceDbContext>();
            services.AddDbContext<PersistenceDbContext>();

            StartupAdminUserManagement(services);
            StartupAccounting(services);
            StartupLogin(services);
            StartupSessions(services);
        }

        private static void StartupAccounting(IServiceCollection services)
        {
            // AccountingEntries
            services.AddScoped<IAccountingEntriesCrudRepository, AccountingEntriesCrudRepository>();

            // Categories
            services.AddScoped<ICategoriesCrudRepository, CategoriesCrudRepository>();

            // StartSalden
            services.AddScoped<IStartSaldenCrudRepository, StartSaldenCrudRepository>();

            // CategorySearchTerms
            services.AddScoped<ICategorySearchTermsCrudRepository, CategorySearchTermsCrudRepository>();
        }

        private static void StartupLogin(IServiceCollection services)
        {
            services.AddScoped<IAdminEmailUserFailedLoginAttemptsCrudRepository, AdminEmailUserFailedLoginAttemptsCrudRepository>();
        }

        private static void StartupSessions(IServiceCollection services)
        {
            services.AddScoped<IAdminAccessTokensCrudRepository, AdminAccessTokensCrudRepository>();
            services.AddScoped<IAdminRefreshTokensCrudRepository, AdminRefreshTokensCrudRepository>();
        }

        private static void StartupAdminUserManagement(IServiceCollection services)
        {
            services.AddScoped<IAdminAdGroupMembershipRepository, AdminAdGroupMembershipRepository>();
            services.AddScoped<IAdminAdGroupsCrudRepository, AdminAdGroupsCrudRepository>();
            services.AddScoped<IAdminAdUserMembershipRepository, AdminAdUserMembershipRepository>();
            services.AddScoped<IAdminAdUsersCrudRepository, AdminAdUsersCrudRepository>();
            services.AddScoped<IAdminEmailUserMembershipRepository, AdminEmailUserMembershipRepository>();
            services.AddScoped<IAdminEmailUserPasswordResetTokenRepository, AdminEmailUserPasswordResetTokenRepository>();
            services.AddScoped<IAdminEmailUsersCrudRepository, AdminEmailUsersCrudRepository>();
            services.AddScoped<IAdminUserGroupMembershipRepository, AdminUserGroupMembershipRepository>();
            services.AddScoped<IAdminUserGroupsCrudRepository, AdminUserGroupsCrudRepository>();
        }
    }
}