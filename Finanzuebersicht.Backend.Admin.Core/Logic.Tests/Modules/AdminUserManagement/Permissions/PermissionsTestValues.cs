using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminUserManagement.Permissions;
using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.Tests.Modules.AdminUserManagement.Permissions
{
    public class PermissionsTestValues
    {
        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault = PreparePermissions(0, 1, 1, 0, 1);
        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault2 = PreparePermissions(1, 1, 2, 0, 0);
        public static readonly IDictionary<string, PermissionStatus> PermissionsDefault3 = PreparePermissions(1, 1, 2, 0, 2);
        public static readonly IDictionary<string, PermissionStatus> PermissionsForCreate = PermissionsCalculation.GetPermissionsWithStatus(PermissionStatus.NOT_SET);
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdate = PreparePermissions(1, 2, 0, 1, 0);
        public static readonly IDictionary<string, PermissionStatus> PermissionsForUpdateGlobalAdmin = PreparePermissions(1, 2, 0, 1, 1);

        public static readonly IDictionary<string, PermissionStatus> CalculatedPermissions1And2 = PreparePermissions(1, 1, 2, 0, 1);
        public static readonly IDictionary<string, PermissionStatus> CalculatedPermissions1And2And3 = PreparePermissions(1, 1, 2, 0, 2);

        public static readonly IDictionary<string, PermissionStatus> CalculatedStrictPermissions1And2 = PreparePermissions(1, 1, 2, 2, 1);
        public static readonly IDictionary<string, PermissionStatus> CalculatedStrictPermissions1And3 = PreparePermissions(1, 1, 2, 2, 2);
        public static readonly IDictionary<string, PermissionStatus> CalculatedStrictPermissions1And2And3 = PreparePermissions(1, 1, 2, 2, 2);

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