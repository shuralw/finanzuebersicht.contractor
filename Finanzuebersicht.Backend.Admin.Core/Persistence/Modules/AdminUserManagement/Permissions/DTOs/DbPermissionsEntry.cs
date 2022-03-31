using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using System;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions
{
    internal static class DbPermissionsEntry
    {
        public static IDictionary<string, PermissionStatus> FromEfPermissionsEntry(IEfPermissionsEntry efPermissionsEntry)
        {
            if (efPermissionsEntry == null)
            {
                return null;
            }

            return new Dictionary<string, PermissionStatus>()
                {
                    { PermissionName.Benutzerverwaltung, (PermissionStatus)efPermissionsEntry.Benutzerverwaltung },
                    { PermissionName.BerichteBearbeiten, (PermissionStatus)efPermissionsEntry.BerichteBearbeiten },
                    { PermissionName.BerichteLesen, (PermissionStatus)efPermissionsEntry.BerichteLesen },
                    { PermissionName.BetriebBearbeiten, (PermissionStatus)efPermissionsEntry.BetriebBearbeiten },
                    { PermissionName.BetriebLesen, (PermissionStatus)efPermissionsEntry.BetriebLesen },
                    { PermissionName.DokumenteBearbeiten, (PermissionStatus)efPermissionsEntry.DokumenteBearbeiten },
                    { PermissionName.DokumenteLesen, (PermissionStatus)efPermissionsEntry.DokumenteLesen },
                    { PermissionName.GebietskoerperschaftBearbeiten, (PermissionStatus)efPermissionsEntry.GebietskoerperschaftBearbeiten },
                    { PermissionName.GebietskoerperschaftLesen, (PermissionStatus)efPermissionsEntry.GebietskoerperschaftLesen },
                    { PermissionName.GrundDatenBearbeiten, (PermissionStatus)efPermissionsEntry.GrundDatenBearbeiten },
                    { PermissionName.GrundDatenLesen, (PermissionStatus)efPermissionsEntry.GrundDatenLesen },
                    { PermissionName.HilfetextBearbeiten, (PermissionStatus)efPermissionsEntry.HilfetextBearbeiten },
                    { PermissionName.HilfetextLesen, (PermissionStatus)efPermissionsEntry.HilfetextLesen },
                    { PermissionName.ImportExportSchemataBearbeiten, (PermissionStatus)efPermissionsEntry.ImportExportSchemataBearbeiten },
                    { PermissionName.ImportExportSchemataLesen, (PermissionStatus)efPermissionsEntry.ImportExportSchemataLesen },
                    { PermissionName.LoginAlsBetrieb, (PermissionStatus)efPermissionsEntry.LoginAlsBetrieb },
                    { PermissionName.LoginAlsGebietskoerperschaft, (PermissionStatus)efPermissionsEntry.LoginAlsGebietskoerperschaft },
                    { PermissionName.LoginAlsSchule, (PermissionStatus)efPermissionsEntry.LoginAlsSchule },
                    { PermissionName.LoginAlsSchulkind, (PermissionStatus)efPermissionsEntry.LoginAlsSchulkind },
                    { PermissionName.NachrichtenBearbeiten, (PermissionStatus)efPermissionsEntry.NachrichtenBearbeiten },
                    { PermissionName.NachrichtenLesen, (PermissionStatus)efPermissionsEntry.NachrichtenLesen },
                    { PermissionName.NewsletterBearbeiten, (PermissionStatus)efPermissionsEntry.NewsletterBearbeiten },
                    { PermissionName.NewsletterLesen, (PermissionStatus)efPermissionsEntry.NewsletterLesen },
                    { PermissionName.SchuleBearbeiten, (PermissionStatus)efPermissionsEntry.SchuleBearbeiten },
                    { PermissionName.SchuleLesen, (PermissionStatus)efPermissionsEntry.SchuleLesen },
                    { PermissionName.SchulkindBearbeiten, (PermissionStatus)efPermissionsEntry.SchulkindBearbeiten },
                    { PermissionName.SchulkindLesen, (PermissionStatus)efPermissionsEntry.SchulkindLesen },
                    { PermissionName.SchulsystemBearbeiten, (PermissionStatus)efPermissionsEntry.SchulsystemBearbeiten },
                    { PermissionName.SchulsystemLesen, (PermissionStatus)efPermissionsEntry.SchulsystemLesen },
                    { PermissionName.StatistikenBearbeiten, (PermissionStatus)efPermissionsEntry.StatistikenBearbeiten },
                    { PermissionName.StatistikenLesen, (PermissionStatus)efPermissionsEntry.StatistikenLesen },
                };
        }

        public static void UpdateEfPermissionsEntry(IEfPermissionsEntry permissions, IDictionary<string, PermissionStatus> sessionPermissions)
        {
            permissions.Benutzerverwaltung = (decimal)sessionPermissions[PermissionName.Benutzerverwaltung];
            permissions.BerichteBearbeiten = (decimal)sessionPermissions[PermissionName.BerichteBearbeiten];
            permissions.BerichteLesen = (decimal)sessionPermissions[PermissionName.BerichteLesen];
            permissions.BetriebBearbeiten = (decimal)sessionPermissions[PermissionName.BetriebBearbeiten];
            permissions.BetriebLesen = (decimal)sessionPermissions[PermissionName.BetriebLesen];
            permissions.DokumenteBearbeiten = (decimal)sessionPermissions[PermissionName.DokumenteBearbeiten];
            permissions.DokumenteLesen = (decimal)sessionPermissions[PermissionName.DokumenteLesen];
            permissions.GebietskoerperschaftBearbeiten = (decimal)sessionPermissions[PermissionName.GebietskoerperschaftBearbeiten];
            permissions.GebietskoerperschaftLesen = (decimal)sessionPermissions[PermissionName.GebietskoerperschaftLesen];
            permissions.GrundDatenBearbeiten = (decimal)sessionPermissions[PermissionName.GrundDatenBearbeiten];
            permissions.GrundDatenLesen = (decimal)sessionPermissions[PermissionName.GrundDatenLesen];
            permissions.HilfetextBearbeiten = (decimal)sessionPermissions[PermissionName.HilfetextBearbeiten];
            permissions.HilfetextLesen = (decimal)sessionPermissions[PermissionName.HilfetextLesen];
            permissions.ImportExportSchemataBearbeiten = (decimal)sessionPermissions[PermissionName.ImportExportSchemataBearbeiten];
            permissions.ImportExportSchemataLesen = (decimal)sessionPermissions[PermissionName.ImportExportSchemataLesen];
            permissions.LoginAlsBetrieb = (decimal)sessionPermissions[PermissionName.LoginAlsBetrieb];
            permissions.LoginAlsGebietskoerperschaft = (decimal)sessionPermissions[PermissionName.LoginAlsGebietskoerperschaft];
            permissions.LoginAlsSchule = (decimal)sessionPermissions[PermissionName.LoginAlsSchule];
            permissions.LoginAlsSchulkind = (decimal)sessionPermissions[PermissionName.LoginAlsSchulkind];
            permissions.NachrichtenBearbeiten = (decimal)sessionPermissions[PermissionName.NachrichtenBearbeiten];
            permissions.NachrichtenLesen = (decimal)sessionPermissions[PermissionName.NachrichtenLesen];
            permissions.NewsletterBearbeiten = (decimal)sessionPermissions[PermissionName.NewsletterBearbeiten];
            permissions.NewsletterLesen = (decimal)sessionPermissions[PermissionName.NewsletterLesen];
            permissions.SchuleBearbeiten = (decimal)sessionPermissions[PermissionName.SchuleBearbeiten];
            permissions.SchuleLesen = (decimal)sessionPermissions[PermissionName.SchuleLesen];
            permissions.SchulkindBearbeiten = (decimal)sessionPermissions[PermissionName.SchulkindBearbeiten];
            permissions.SchulkindLesen = (decimal)sessionPermissions[PermissionName.SchulkindLesen];
            permissions.SchulsystemBearbeiten = (decimal)sessionPermissions[PermissionName.SchulsystemBearbeiten];
            permissions.SchulsystemLesen = (decimal)sessionPermissions[PermissionName.SchulsystemLesen];
            permissions.StatistikenBearbeiten = (decimal)sessionPermissions[PermissionName.StatistikenBearbeiten];
            permissions.StatistikenLesen = (decimal)sessionPermissions[PermissionName.StatistikenLesen];
        }

        public static EfAdminEmailUserPermissionsEntry ToEfAdminEmailUserPermissionsEntry(Guid adminEmailUserId, IDictionary<string, PermissionStatus> permissions)
        {
            var efAdminEmailUserPermissionsEntry = new EfAdminEmailUserPermissionsEntry() { AdminEmailUserId = adminEmailUserId };
            UpdateEfPermissionsEntry(efAdminEmailUserPermissionsEntry, permissions);
            return efAdminEmailUserPermissionsEntry;
        }

        public static EfAdminUserGroupPermissionsEntry ToEfAdminUserGroupPermissionsEntry(Guid adminUserGroupId, IDictionary<string, PermissionStatus> permissions)
        {
            var efAdminUserGroupPermissionsEntry = new EfAdminUserGroupPermissionsEntry() { AdminUserGroupId = adminUserGroupId };
            UpdateEfPermissionsEntry(efAdminUserGroupPermissionsEntry, permissions);
            return efAdminUserGroupPermissionsEntry;
        }

        public static EfAdminAdUserPermissionsEntry ToEfAdminAdUserPermissionsEntry(Guid adminAdUserId, IDictionary<string, PermissionStatus> permissions)
        {
            var efAdminAdUserPermissionsEntry = new EfAdminAdUserPermissionsEntry() { AdminAdUserId = adminAdUserId };
            UpdateEfPermissionsEntry(efAdminAdUserPermissionsEntry, permissions);
            return efAdminAdUserPermissionsEntry;
        }

        public static EfAdminAdGroupPermissionsEntry ToEfAdminAdGroupPermissionsEntry(Guid adminAdGroupId, IDictionary<string, PermissionStatus> permissions)
        {
            var efAdminAdGroupPermissionsEntry = new EfAdminAdGroupPermissionsEntry() { AdminAdGroupId = adminAdGroupId };
            UpdateEfPermissionsEntry(efAdminAdGroupPermissionsEntry, permissions);
            return efAdminAdGroupPermissionsEntry;
        }

        public static EfAdminAccessTokenCachedPermissionsEntry ToEfAdminAccessTokenCachedPermissions(Guid adminAccessTokenId, IDictionary<string, PermissionStatus> permissions)
        {
            var efAdminAdGroupPermissionsEntry = new EfAdminAccessTokenCachedPermissionsEntry() { AdminAccessTokenId = adminAccessTokenId };
            UpdateEfPermissionsEntry(efAdminAdGroupPermissionsEntry, permissions);
            return efAdminAdGroupPermissionsEntry;
        }
    }
}