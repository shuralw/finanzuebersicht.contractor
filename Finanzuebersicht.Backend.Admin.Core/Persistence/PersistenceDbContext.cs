using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.CategorySearchTerms;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.Categories;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.AccountingEntries;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Accounting.StartSalden;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence
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

        public virtual DbSet<EfAdminAdGroup> AdminAdGroups { get; set; }

        public virtual DbSet<EfAdminAdGroupAdminUserGroupRelation> AdminAdGroupAdminUserGroupRelations { get; set; }

        public virtual DbSet<EfAdminAdGroupPermissionsEntry> AdminAdGroupPermissions { get; set; }

        public virtual DbSet<EfAdminAdUser> AdminAdUsers { get; set; }

        public virtual DbSet<EfAdminAdUserAdminUserGroupRelation> AdminAdUserAdminUserGroupRelations { get; set; }

        public virtual DbSet<EfAdminAdUserPermissionsEntry> AdminAdUserPermissions { get; set; }

        public virtual DbSet<EfAdminEmailUser> AdminEmailUsers { get; set; }

        public virtual DbSet<EfAdminEmailUserFailedLoginAttempt> AdminEmailUserFailedLoginAttempts { get; set; }

        public virtual DbSet<EfAdminEmailUserAdminUserGroupRelation> AdminEmailUserAdminUserGroupRelations { get; set; }

        public virtual DbSet<EfAdminEmailUserPasswordResetToken> AdminEmailUserPasswordResetTokens { get; set; }

        public virtual DbSet<EfAdminEmailUserPermissionsEntry> AdminEmailUserPermissions { get; set; }

        public virtual DbSet<EfAdminAccessToken> AdminAccessTokens { get; set; }

        public virtual DbSet<EfAdminAccessTokenAdminAdGroupRelation> AdminAccessTokenAdminAdGroupRelations { get; set; }

        public virtual DbSet<EfAdminAccessTokenCachedPermissionsEntry> AdminAccessTokenCachedPermissions { get; set; }

        public virtual DbSet<EfAdminRefreshToken> AdminRefreshTokens { get; set; }

        public virtual DbSet<EfAdminRefreshTokenAdminAdGroupRelation> AdminRefreshTokenAdminAdGroupRelations { get; set; }

        public virtual DbSet<EfAdminUserGroup> AdminUserGroups { get; set; }

        public virtual DbSet<EfAdminUserGroupAdminUserGroupRelation> AdminUserGroupAdminUserGroupRelations { get; set; }

        public virtual DbSet<EfAdminUserGroupPermissionsEntry> AdminUserGroupPermissions { get; set; }

        public virtual DbSet<EfAccountingEntry> AccountingEntries { get; set; }

        public virtual DbSet<EfCategory> Categories { get; set; }

        public virtual DbSet<EfCategorySearchTerm> CategorySearchTerms { get; set; }

        public virtual DbSet<EfStartSaldo> StartSalden { get; set; }

        public static PersistenceDbContext CustomInstantiate(DbContextOptions<PersistenceDbContext> options)
        {
            return new PersistenceDbContext(options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationSection section = this.configuration.GetSection("DatabaseConnections:Finanzuebersicht.Database.Core");
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
            modelBuilder.Entity<EfAdminAdGroupAdminUserGroupRelation>(entity =>
           {
               entity.HasKey(e => new { e.MemberId, e.ParentId })
                   .HasName("PK_AdminAdGroupAdminUserGroupRelation_MemberId_ParentId");

               entity.HasOne(d => d.Member)
                   .WithMany(p => p.AdminAdGroupAdminUserGroupRelations)
                   .HasForeignKey(d => d.MemberId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_AdminAdGroupAdminUserGroupRelation_MemberId");

               entity.HasOne(d => d.Parent)
                   .WithMany(p => p.AdminAdGroupAdminUserGroupRelations)
                   .HasForeignKey(d => d.ParentId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_AdminAdGroupAdminUserGroupRelation_ParentId");
           });

            modelBuilder.Entity<EfAdminAdGroupPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdminAdGroupId)
                    .HasName("PK_AdminAdGroupPermissions_AdminAdGroupId");

                entity.Property(e => e.AdminAdGroupId).ValueGeneratedNever();

                entity.Property(e => e.Benutzerverwaltung).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsBetrieb).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsGebietskoerperschaft).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchule).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchulkind).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenLesen).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdminAdGroup)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfAdminAdGroupPermissionsEntry>(d => d.AdminAdGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminAdGroupPermissions_AdminAdGroupId");
            });

            modelBuilder.Entity<EfAdminAdGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dn)
                    .IsRequired()
                    .HasColumnName("DN")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfAdminAdUserAdminUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_AdminAdUserAdminUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.AdminAdUserAdminUserGroupRelations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminAdUserAdminUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.AdminAdUserAdminUserGroupRelations)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminAdUserAdminUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfAdminAdUserPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdminAdUserId)
                    .HasName("PK_AdminAdUserPermissions_AdminAdUserId");

                entity.Property(e => e.AdminAdUserId).ValueGeneratedNever();

                entity.Property(e => e.Benutzerverwaltung).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsBetrieb).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsGebietskoerperschaft).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchule).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchulkind).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenLesen).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdminAdUser)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfAdminAdUserPermissionsEntry>(d => d.AdminAdUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminAdUserPermissions_AdminAdUserId");
            });

            modelBuilder.Entity<EfAdminAdUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dn)
                    .IsRequired()
                    .HasColumnName("DN")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfAdminEmailUserFailedLoginAttempt>(entity =>
            {
                entity.Property(e => e.OccurredAt).HasColumnType("datetime");

                entity.HasOne(d => d.AdminEmailUser)
                    .WithMany(p => p.AdminEmailUserFailedLoginAttempts)
                    .HasForeignKey(d => d.AdminEmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminEmailUserFailedLoginAttempts_AdminEmailUserId");
            });

            modelBuilder.Entity<EfAdminEmailUserAdminUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_AdminEmailUserAdminUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.AdminEmailUserAdminUserGroupRelations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminEmailUserAdminUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.AdminEmailUserAdminUserGroupRelations)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminEmailUserAdminUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfAdminEmailUserPasswordResetToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("PK_AdminEmailUserPasswordResetToken_Token");

                entity.Property(e => e.Token).HasMaxLength(64);

                entity.Property(e => e.AdminEmailUserId).IsRequired();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.HasOne(d => d.AdminEmailUser)
                    .WithMany(p => p.AdminEmailUserPasswordResetTokens)
                    .HasForeignKey(d => d.AdminEmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminEmailUserPasswordResetToken_AdminEmailUserId");
            });

            modelBuilder.Entity<EfAdminEmailUserPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdminEmailUserId)
                    .HasName("PK_AdminEmailUserPermissions_AdminEmailUserId");

                entity.Property(e => e.AdminEmailUserId).ValueGeneratedNever();

                entity.Property(e => e.Benutzerverwaltung).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsBetrieb).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsGebietskoerperschaft).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchule).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchulkind).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenLesen).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdminEmailUser)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfAdminEmailUserPermissionsEntry>(d => d.AdminEmailUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminEmailUserPermissions_AdminEmailUserId");
            });

            modelBuilder.Entity<EfAdminEmailUser>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("AdminEmailUsersEmailUnique")
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

            modelBuilder.Entity<EfAdminAccessToken>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.AdminRefreshToken)
                    .WithMany(p => p.AdminAccessTokens)
                    .HasForeignKey(d => d.AdminRefreshTokenId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminAccessTokens_AdminRefreshTokenId");
            });

            modelBuilder.Entity<EfAdminAccessTokenAdminAdGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.AdminAccessTokenId, e.AdminAdGroupId })
                    .HasName("PK_AdminAccessTokenAdminAdGroupRelations_Token_AdminAdGroupId");

                entity.HasOne(d => d.AdminAccessToken)
                    .WithMany(p => p.AdminAccessTokenAdminAdGroupRelations)
                    .HasForeignKey(d => d.AdminAccessTokenId)
                    .HasConstraintName("FK_AdminAccessTokenAdminAdGroupRelations_AdminAccessTokenId");
            });

            modelBuilder.Entity<EfAdminAccessTokenCachedPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdminAccessTokenId)
                    .HasName("PK_AdminAccessTokenCachedPermissions_AdminAccessTokenId");

                entity.Property(e => e.AdminAccessTokenId).ValueGeneratedNever();

                entity.Property(e => e.Benutzerverwaltung).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsBetrieb).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsGebietskoerperschaft).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchule).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchulkind).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenLesen).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdminAccessToken)
                    .WithOne(p => p.AdminAccessTokenCachedPermissions)
                    .HasForeignKey<EfAdminAccessTokenCachedPermissionsEntry>(d => d.AdminAccessTokenId)
                    .HasConstraintName("FK_AdminAccessTokenCachedPermissions_AdminAccessTokenId");
            });

            modelBuilder.Entity<EfAdminRefreshToken>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpiresOn).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<EfAdminRefreshTokenAdminAdGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.AdminRefreshTokenId, e.AdminAdGroupId })
                    .HasName("PK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId_AdminAdGroupId");

                entity.HasOne(d => d.AdminRefreshToken)
                    .WithMany(p => p.AdminRefreshTokenAdminAdGroupRelations)
                    .HasForeignKey(d => d.AdminRefreshTokenId)
                    .HasConstraintName("FK_AdminRefreshTokenAdminAdGroupRelations_AdminRefreshTokenId");
            });

            modelBuilder.Entity<EfAdminUserGroupAdminUserGroupRelation>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.ParentId })
                    .HasName("PK_AdminUserGroupAdminUserGroupRelation_MemberId_ParentId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.AdminUserGroupAdminUserGroupRelationsMember)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminUserGroupAdminUserGroupRelation_MemberId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.AdminUserGroupAdminUserGroupRelationsParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminUserGroupAdminUserGroupRelation_ParentId");
            });

            modelBuilder.Entity<EfAdminUserGroupPermissionsEntry>(entity =>
            {
                entity.HasKey(e => e.AdminUserGroupId)
                    .HasName("AdminUserGroupPermissions");

                entity.Property(e => e.AdminUserGroupId).ValueGeneratedNever();

                entity.Property(e => e.Benutzerverwaltung).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BerichteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.BetriebLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.DokumenteLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GebietskoerperschaftLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.GrundDatenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.HilfetextLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.ImportExportSchemataLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsBetrieb).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsGebietskoerperschaft).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchule).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.LoginAlsSchulkind).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NachrichtenLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.NewsletterLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchuleLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulkindLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.SchulsystemLesen).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenBearbeiten).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.StatistikenLesen).HasColumnType("numeric(1, 0)");

                entity.HasOne(d => d.AdminUserGroup)
                    .WithOne(p => p.Permissions)
                    .HasForeignKey<EfAdminUserGroupPermissionsEntry>(d => d.AdminUserGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AdminUserGroupPermissions_AdminUserGroupId");
            });

            modelBuilder.Entity<EfAdminUserGroup>(entity =>
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
                    .HasMaxLength(4000);

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
                    .HasMaxLength(1000);

                entity.Property(e => e.Beguenstigter)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.IBAN)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BIC)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Waehrung)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasMaxLength(4000);
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

                entity.Property(e => e.AmDatum).HasColumnType("datetime");
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
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}