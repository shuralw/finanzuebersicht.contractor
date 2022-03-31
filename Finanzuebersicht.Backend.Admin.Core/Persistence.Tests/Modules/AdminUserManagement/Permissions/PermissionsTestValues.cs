using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.Permissions
{
    public class PermissionsTestValues
    {
        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault = PreparePermissions(0, 1, 1, 0, 2);
        public static readonly IDictionary<string, PermissionStatus> PermissionsDbDefault2 = PreparePermissions(1, 1, 2, 0, 2);
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PreparePermissions(2, 1, 1, 2, 2);
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PreparePermissions(1, 2, 0, 1, 1);

        private static IDictionary<string, PermissionStatus> PreparePermissions(
            decimal benutzerverwaltung,
            decimal berichteBearbeiten,
            decimal berichteLesen,
            decimal betriebBearbeiten,
            decimal betriebLesen)
        {
            return new Dictionary<string, PermissionStatus>()
                {
                    { PermissionName.Benutzerverwaltung, (PermissionStatus)benutzerverwaltung },
                    { PermissionName.BerichteBearbeiten, (PermissionStatus)berichteBearbeiten },
                    { PermissionName.BerichteLesen, (PermissionStatus)berichteLesen },
                    { PermissionName.BetriebBearbeiten, (PermissionStatus)betriebBearbeiten },
                    { PermissionName.BetriebLesen, (PermissionStatus)betriebLesen },
                    { PermissionName.DokumenteBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.DokumenteLesen, PermissionStatus.ALLOW },
                    { PermissionName.GebietskoerperschaftBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.GebietskoerperschaftLesen, PermissionStatus.ALLOW },
                    { PermissionName.GrundDatenBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.GrundDatenLesen, PermissionStatus.ALLOW },
                    { PermissionName.HilfetextBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.HilfetextLesen, PermissionStatus.ALLOW },
                    { PermissionName.ImportExportSchemataBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.ImportExportSchemataLesen, PermissionStatus.ALLOW },
                    { PermissionName.LoginAlsBetrieb, PermissionStatus.ALLOW },
                    { PermissionName.LoginAlsGebietskoerperschaft, PermissionStatus.ALLOW },
                    { PermissionName.LoginAlsSchule, PermissionStatus.ALLOW },
                    { PermissionName.LoginAlsSchulkind, PermissionStatus.ALLOW },
                    { PermissionName.NachrichtenBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.NachrichtenLesen, PermissionStatus.ALLOW },
                    { PermissionName.NewsletterBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.NewsletterLesen, PermissionStatus.ALLOW },
                    { PermissionName.SchuleBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.SchuleLesen, PermissionStatus.ALLOW },
                    { PermissionName.SchulkindBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.SchulkindLesen, PermissionStatus.ALLOW },
                    { PermissionName.SchulsystemBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.SchulsystemLesen, PermissionStatus.ALLOW },
                    { PermissionName.StatistikenBearbeiten, PermissionStatus.ALLOW },
                    { PermissionName.StatistikenLesen, PermissionStatus.ALLOW },
                };
        }
    }
}