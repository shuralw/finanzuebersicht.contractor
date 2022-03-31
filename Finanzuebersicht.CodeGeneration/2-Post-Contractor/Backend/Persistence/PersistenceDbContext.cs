using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Generated.Persistence.Modules.Accounting.StartSalden;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchuelerOnline.Backend.Generated.Persistence.Modules.LoginSystem.EmailUserFailedLoginAttempts;
using SchuelerOnline.Backend.Generated.Persistence.Modules.MandantenTrennung.Mandanten;
using SchuelerOnline.Backend.Generated.Persistence.Modules.SessionManagement.AccessTokens;
using SchuelerOnline.Backend.Generated.Persistence.Modules.SessionManagement.RefreshTokens;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.AdGroups;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.AdUsers;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.EmailUserPasswordReset;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.EmailUsers;
using SchuelerOnline.Backend.Generated.Persistence.Modules.UserManagement.UserGroups;

namespace SchuelerOnline.Backend.Generated.Persistence
{
    public partial class PersistenceDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public PersistenceDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private PersistenceDbContext(DbContextOptions<PersistenceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EfAdGroup> AdGroups { get; set; }

        public virtual DbSet<EfAdGroupUserGroupRelation> AdGroupUserGroupRelations { get; set; }

        public virtual DbSet<EfAdGroupPermissionsEntry> AdGroupPermissions { get; set; }

        public virtual DbSet<EfAdUser> AdUsers { get; set; }

        public virtual DbSet<EfAdUserUserGroupRelation> AdUserUserGroupRelations { get; set; }

        public virtual DbSet<EfAdUserPermissionsEntry> AdUserPermissions { get; set; }

        public virtual DbSet<EfEmailUser> EmailUsers { get; set; }

        public virtual DbSet<EfEmailUserFailedLoginAttempt> EmailUserFailedLoginAttempts { get; set; }

        public virtual DbSet<EfEmailUserUserGroupRelation> EmailUserUserGroupRelations { get; set; }

        public virtual DbSet<EfEmailUserPasswordResetToken> EmailUserPasswordResetTokens { get; set; }

        public virtual DbSet<EfEmailUserPermissionsEntry> EmailUserPermissions { get; set; }

        public virtual DbSet<EfMandant> Mandanten { get; set; }

        public virtual DbSet<EfAccessToken> AccessTokens { get; set; }

        public virtual DbSet<EfAccessTokenAdGroupRelation> AccessTokenAdGroupRelations { get; set; }

        public virtual DbSet<EfAccessTokenCachedPermissionsEntry> AccessTokenCachedPermissions { get; set; }

        public virtual DbSet<EfRefreshToken> RefreshTokens { get; set; }

        public virtual DbSet<EfRefreshTokenAdGroupRelation> RefreshTokenAdGroupRelations { get; set; }

        public virtual DbSet<EfUserGroup> UserGroups { get; set; }

        public virtual DbSet<EfUserGroupUserGroupRelation> UserGroupUserGroupRelations { get; set; }

        public virtual DbSet<EfUserGroupPermissionsEntry> UserGroupPermissions { get; set; }

        public virtual DbSet<EfAccountingEntry> AccountingEntries { get; set; }

        public virtual DbSet<EfCategory> Categories { get; set; }

        public virtual DbSet<EfStartSaldo> StartSalden { get; set; }

        public virtual DbSet<EfCategorySearchTerm> CategorySearchTerms { get; set; }

        public static PersistenceDbContext CustomInstantiate(DbContextOptions<PersistenceDbContext> options)
        {
            return new PersistenceDbContext(options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationSection section = this.configuration.GetSection("DatabaseConnections:SchuelerOnline.Database.Core");
                string connectionStringTemplate = section.GetSection("ConnectionStringTemplate").Value;
                connectionStringTemplate = connectionStringTemplate.Replace("{{ServerAddress}}", section.GetSection("ServerAddress").Value);
                connectionStringTemplate = connectionStringTemplate.Replace("{{DatabaseName}}", section.GetSection("DatabaseName").Value);
                connectionStringTemplate = connectionStringTemplate.Replace("{{Username}}", section.GetSection("Username").Value);
                connectionStringTemplate = connectionStringTemplate.Replace("{{Password}}", section.GetSection("Password").Value);
                optionsBuilder.UseSqlServer(connectionStringTemplate);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfAdGroupUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_AdGroupUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.AdGroupUserGroupRelations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdGroupUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.AdGroupUserGroupRelations)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdGroupUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfAdGroupPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdGroupId)
                    .HasName("PK_AdGroupPermissions_AdGroupId");

                entity.Property(e => e.AdGroupId).ValueGeneratedNever();

                entity.Property(e => e.BenutzerVerwalten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission1).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission2).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission3).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MandantenVerwalten).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdGroup)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfAdGroupPermissionsEntry>(d => d.AdGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdGroupPermissions_AdGroupId");
            });

            modelBuilder.Entity<EfAdGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dn)
                    .IsRequired()
                    .HasColumnName("DN")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfAdUserUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_AdUserUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.AdUserUserGroupRelations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdUserUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.AdUserUserGroupRelations)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdUserUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfAdUserPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdUserId)
                    .HasName("PK_AdUserPermissions_AdUserId");

                entity.Property(e => e.AdUserId).ValueGeneratedNever();

                entity.Property(e => e.BenutzerVerwalten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission1).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission2).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission3).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MandantenVerwalten).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdUser)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfAdUserPermissionsEntry>(d => d.AdUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdUserPermissions_AdUserId");
            });

            modelBuilder.Entity<EfAdUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dn)
                    .IsRequired()
                    .HasColumnName("DN")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfEmailUserFailedLoginAttempt>(entity =>
            {
                entity.Property(e => e.OccurredAt).HasColumnType("datetime");

                entity.HasOne(d => d.EmailUser)
                    .WithMany(p => p.EmailUserFailedLoginAttempts)
                    .HasForeignKey(d => d.EmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailUserFailedLoginAttempts_EmailUserId");
            });

            modelBuilder.Entity<EfEmailUserUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_EmailUserUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.EmailUserUserGroupRelations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailUserUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.EmailUserUserGroupRelations)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailUserUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfEmailUserPasswordResetToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK_EmailUserPasswordResetToken_Token");

                entity.Property(e => e.Token).HasMaxLength(64);

                entity.Property(e => e.EmailUserId).IsRequired();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.HasOne(d => d.EmailUser)
                    .WithMany(p => p.EmailUserPasswordResetTokens)
                    .HasForeignKey(d => d.EmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailUserPasswordResetToken_EmailUserId");
            });

            modelBuilder.Entity<EfEmailUserPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.EmailUserId)
                    .HasName("PK_EmailUserPermissions_EmailUserId");

                entity.Property(e => e.EmailUserId).ValueGeneratedNever();

                entity.Property(e => e.ExamplePermission1).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission2).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission3).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BenutzerVerwalten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MandantenVerwalten).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.EmailUser)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfEmailUserPermissionsEntry>(d => d.EmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EmailUserPermissions_EmailUserId");
            });

            modelBuilder.Entity<EfEmailUser>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("EmailUsersEmailUnique")
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(88);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(54);
            });

            modelBuilder.Entity<EfMandant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Deaktiviert)
                    .IsRequired();
            });

            modelBuilder.Entity<EfAccessToken>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.RefreshToken)
                    .WithMany(p => p.AccessTokens)
                    .HasForeignKey(d => d.RefreshTokenId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AccessTokens_RefreshTokenId");
            });

            modelBuilder.Entity<EfAccessTokenAdGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.AccessTokenId, e.AdGroupId })
                    .HasName("PK_AccessTokenAdGroupRelations_Token_AdGroupId");

                entity.HasOne(d => d.AccessToken)
                    .WithMany(p => p.AccessTokenAdGroupRelations)
                    .HasForeignKey(d => d.AccessTokenId)
                    .HasConstraintName("FK_AccessTokenAdGroupRelations_AccessTokenId");
            });

            modelBuilder.Entity<EfAccessTokenCachedPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AccessTokenId)
                    .HasName("PK_AccessTokenCachedPermissions_AccessTokenId");

                entity.Property(e => e.AccessTokenId).ValueGeneratedNever();

                entity.Property(e => e.BenutzerVerwalten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission1).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission2).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission3).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MandantenVerwalten).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AccessToken)
                    .WithOne(p => p.AccessTokenCachedPermissions)
                    .HasForeignKey<EfAccessTokenCachedPermissionsEntry>(d => d.AccessTokenId)
                    .HasConstraintName("FK_AccessTokenCachedPermissions_AccessTokenId");
            });

            modelBuilder.Entity<EfRefreshToken>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfRefreshTokenAdGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.RefreshTokenId, e.AdGroupId })
                    .HasName("PK_RefreshTokenAdGroupRelations_RefreshTokenId_AdGroupId");

                entity.HasOne(d => d.RefreshToken)
                    .WithMany(p => p.RefreshTokenAdGroupRelations)
                    .HasForeignKey(d => d.RefreshTokenId)
                    .HasConstraintName("FK_RefreshTokenAdGroupRelations_RefreshTokenId");
            });

            modelBuilder.Entity<EfUserGroupUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_UserGroupUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.UserGroupUserGroupRelationsMember)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserGroupUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.UserGroupUserGroupRelationsParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserGroupUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfUserGroupPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.UserGroupId)
                    .HasName("UserGroupPermissions");

                entity.Property(e => e.UserGroupId).ValueGeneratedNever();

                entity.Property(e => e.BenutzerVerwalten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission1).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission2).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ExamplePermission3).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.MandantenVerwalten).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.UserGroup)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfUserGroupPermissionsEntry>(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserGroupPermissions_UserGroupId");
            });

            modelBuilder.Entity<EfUserGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfAccountingEntry>(entity =>
            {
                entity.ToTable("AccountingEntries");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AccountingEntries)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_AccountingEntries_CategoryId");

                entity.Property(e => e.Auftragskonto)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Buchungsdatum).HasColumnType("datetime");

                entity.Property(e => e.ValutaDatum).HasColumnType("datetime");

                entity.Property(e => e.Buchungstext)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Verwendungszweck)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.GlaeubigerId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mandatsreferenz)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sammlerreferenz)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AuslagenersatzRuecklastschrift)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Beguenstigter)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IBAN)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.BIC)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Waehrung)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EfCategory>(entity =>
            {
                entity.ToTable("Categories");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.SuperCategory)
                    .WithMany(p => p.ChildCategories)
                    .HasForeignKey(d => d.SuperCategoryId)
                    .HasConstraintName("FK_Categories_SuperCategoryId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EfStartSaldo>(entity =>
            {
                entity.ToTable("StartSalden");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DatumAm).HasColumnType("datetime");
            });

            modelBuilder.Entity<EfCategorySearchTerm>(entity =>
            {
                entity.ToTable("CategorySearchTerms");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategorySearchTerms)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CategorySearchTerms_CategoryId");

                entity.Property(e => e.Term)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}