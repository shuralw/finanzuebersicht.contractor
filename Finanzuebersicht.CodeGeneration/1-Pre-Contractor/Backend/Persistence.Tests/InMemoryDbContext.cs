using SchuelerOnline.Backend.Generated.Persistence.Modules.LoginSystem.EmailUserFailedLoginAttempts;
using SchuelerOnline.Backend.Generated.Persistence.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Persistence.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Persistence.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.EmailUserPasswordReset;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.Permissions;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.UserGroups;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.LoginSystem.EmailUserFailedLoginAttempts;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.UserManagement.EmailUserPasswordResetTokens;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Persistence.Tests.Modules.UserManagement.UserGroups;
using Microsoft.EntityFrameworkCore;

namespace SchuelerOnline.Backend.Generated.Persistence.Tests
{
    public static class InMemoryDbContext
    {
        public static PersistenceDbContext CreatePersistenceDbContextEmpty()
        {
            DbContextOptions<PersistenceDbContext> options;
            var builder = new DbContextOptionsBuilder<PersistenceDbContext>();
            builder.UseInMemoryDatabase("in-memory-db");
            options = builder.Options;

            PersistenceDbContext persistenceDbContext = PersistenceDbContext.CustomInstantiate(options);
            persistenceDbContext.Database.EnsureDeleted();
            persistenceDbContext.Database.EnsureCreated();

            return persistenceDbContext;
        }

        public static PersistenceDbContext CreatePersistenceDbContextWithDbDefault()
        {
            PersistenceDbContext persistenceDbContext = CreatePersistenceDbContextEmpty();

            // Inserting Test-Data, ordering does not matter, due to missing foreign key checks of mocked DbContext

            // Login System
            persistenceDbContext.EmailUserFailedLoginAttempts.Add(DbEmailUserFailedLoginAttempt.ToEfEmailUserFailedLoginAttempt(DbEmailUserFailedLoginAttemptTest.DbDefault()));
            persistenceDbContext.EmailUserFailedLoginAttempts.Add(DbEmailUserFailedLoginAttempt.ToEfEmailUserFailedLoginAttempt(DbEmailUserFailedLoginAttemptTest.DbDefault2()));
            persistenceDbContext.EmailUserFailedLoginAttempts.Add(DbEmailUserFailedLoginAttempt.ToEfEmailUserFailedLoginAttempt(DbEmailUserFailedLoginAttemptTest.DbDefault3()));

            // MandantenTrennung
            persistenceDbContext.Mandanten.Add(DbMandant.ToEfMandant(DbMandantTest.DbDefault()));
            persistenceDbContext.Mandanten.Add(DbMandant.ToEfMandant(DbMandantTest.DbDefault2()));

            // Session Management
            persistenceDbContext.RefreshTokens.Add(DbRefreshToken.ToEfRefreshToken(DbRefreshTokenTest.DbDefault()));
            persistenceDbContext.RefreshTokenAdGroupRelations.Add(new EfRefreshTokenAdGroupRelation() { RefreshTokenId = RefreshTokenTestValues.IdDbDefault, AdGroupId = AdGroupTestValues.IdDbDefault });
            persistenceDbContext.RefreshTokens.Add(DbRefreshToken.ToEfRefreshToken(DbRefreshTokenTest.DbDefault2()));
            persistenceDbContext.RefreshTokenAdGroupRelations.Add(new EfRefreshTokenAdGroupRelation() { RefreshTokenId = RefreshTokenTestValues.IdDbDefault2, AdGroupId = AdGroupTestValues.IdDbDefault2 });

            persistenceDbContext.AccessTokens.Add(DbAccessToken.ToEfAccessToken(DbAccessTokenTest.DbDefault()));
            persistenceDbContext.AccessTokenAdGroupRelations.Add(new EfAccessTokenAdGroupRelation() { AccessTokenId = AccessTokenTestValues.IdDbDefault, AdGroupId = AdGroupTestValues.IdDbDefault });
            persistenceDbContext.AccessTokenCachedPermissions.Add(DbAccessTokenCachedPermissionsEntry.ToEfAccessTokenCachedPermissions(AccessTokenTestValues.IdDbDefault, AccessTokenTestValues.CachedPermissionsDbDefault));
            persistenceDbContext.AccessTokens.Add(DbAccessToken.ToEfAccessToken(DbAccessTokenTest.DbDefault2()));
            persistenceDbContext.AccessTokenAdGroupRelations.Add(new EfAccessTokenAdGroupRelation() { AccessTokenId = AccessTokenTestValues.IdDbDefault2, AdGroupId = AdGroupTestValues.IdDbDefault2 });
            persistenceDbContext.AccessTokenCachedPermissions.Add(DbAccessTokenCachedPermissionsEntry.ToEfAccessTokenCachedPermissions(AccessTokenTestValues.IdDbDefault2, AccessTokenTestValues.CachedPermissionsDbDefault));

            // UserManagement
            persistenceDbContext.EmailUsers.Add(DbEmailUser.ToEfEmailUser(DbEmailUserTest.DbDefault(), EmailUserTestValues.MandantIdDbDefault));
            persistenceDbContext.EmailUserPermissions.Add(DbPermissionsEntry.ToEfEmailUserPermissionsEntry(EmailUserTestValues.IdDbDefault, EmailUserTestValues.PermissionsDbDefault));
            persistenceDbContext.EmailUsers.Add(DbEmailUser.ToEfEmailUser(DbEmailUserTest.DbDefault2(), EmailUserTestValues.MandantIdDbDefault));
            persistenceDbContext.EmailUserPermissions.Add(DbPermissionsEntry.ToEfEmailUserPermissionsEntry(EmailUserTestValues.IdDbDefault2, EmailUserTestValues.PermissionsDbDefault2));

            persistenceDbContext.EmailUserPasswordResetTokens.Add(DbEmailUserPasswordResetToken.ToEfEmailUserPasswordResetToken(DbEmailUserPasswordResetTokenTest.DbDefault()));
            persistenceDbContext.EmailUserPasswordResetTokens.Add(DbEmailUserPasswordResetToken.ToEfEmailUserPasswordResetToken(DbEmailUserPasswordResetTokenTest.DbDefault2()));

            persistenceDbContext.UserGroups.Add(DbUserGroup.ToEfUserGroup(DbUserGroupTest.DbDefault(), UserGroupTestValues.MandantIdDbDefault));
            persistenceDbContext.UserGroupPermissions.Add(DbPermissionsEntry.ToEfUserGroupPermissionsEntry(UserGroupTestValues.IdDbDefault, UserGroupTestValues.PermissionsDbDefault));
            persistenceDbContext.UserGroups.Add(DbUserGroup.ToEfUserGroup(DbUserGroupTest.DbDefault2(), UserGroupTestValues.MandantIdDbDefault));
            persistenceDbContext.UserGroupPermissions.Add(DbPermissionsEntry.ToEfUserGroupPermissionsEntry(UserGroupTestValues.IdDbDefault2, UserGroupTestValues.PermissionsDbDefault2));
            persistenceDbContext.UserGroups.Add(DbUserGroup.ToEfUserGroup(DbUserGroupTest.DbDefault3(), UserGroupTestValues.MandantIdDbDefault));
            persistenceDbContext.UserGroupPermissions.Add(DbPermissionsEntry.ToEfUserGroupPermissionsEntry(UserGroupTestValues.IdDbDefault3, UserGroupTestValues.PermissionsDbDefault3));

            persistenceDbContext.AdUsers.Add(DbAdUser.ToEfAdUser(DbAdUserTest.DbDefault(), AdUserTestValues.MandantIdDbDefault));
            persistenceDbContext.AdUserPermissions.Add(DbPermissionsEntry.ToEfAdUserPermissionsEntry(AdUserTestValues.IdDbDefault, AdUserTestValues.PermissionsDbDefault));
            persistenceDbContext.AdUsers.Add(DbAdUser.ToEfAdUser(DbAdUserTest.DbDefault2(), AdUserTestValues.MandantIdDbDefault));
            persistenceDbContext.AdUserPermissions.Add(DbPermissionsEntry.ToEfAdUserPermissionsEntry(AdUserTestValues.IdDbDefault2, AdUserTestValues.PermissionsDbDefault2));

            persistenceDbContext.AdGroups.Add(DbAdGroup.ToEfAdGroup(DbAdGroupTest.DbDefault(), AdGroupTestValues.MandantIdDbDefault));
            persistenceDbContext.AdGroupPermissions.Add(DbPermissionsEntry.ToEfAdGroupPermissionsEntry(AdGroupTestValues.IdDbDefault, AdGroupTestValues.PermissionsDbDefault));
            persistenceDbContext.AdGroups.Add(DbAdGroup.ToEfAdGroup(DbAdGroupTest.DbDefault2(), AdGroupTestValues.MandantIdDbDefault));
            persistenceDbContext.AdGroupPermissions.Add(DbPermissionsEntry.ToEfAdGroupPermissionsEntry(AdGroupTestValues.IdDbDefault2, AdGroupTestValues.PermissionsDbDefault2));

            persistenceDbContext.SaveChanges();

            return persistenceDbContext;
        }
    }
}