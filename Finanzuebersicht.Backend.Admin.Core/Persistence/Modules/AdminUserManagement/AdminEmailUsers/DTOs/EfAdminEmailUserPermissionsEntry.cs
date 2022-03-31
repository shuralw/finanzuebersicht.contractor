using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers
{
    [Table("AdminEmailUserPermissions")]
    public partial class EfAdminEmailUserPermissionsEntry : IEfPermissionsEntry
    {
        public Guid AdminEmailUserId { get; set; }

        public decimal Benutzerverwaltung { get; set; }

        public decimal BerichteBearbeiten { get; set; }

        public decimal BerichteLesen { get; set; }

        public decimal BetriebBearbeiten { get; set; }

        public decimal BetriebLesen { get; set; }

        public decimal DokumenteBearbeiten { get; set; }

        public decimal DokumenteLesen { get; set; }

        public decimal GebietskoerperschaftBearbeiten { get; set; }

        public decimal GebietskoerperschaftLesen { get; set; }

        public decimal GrundDatenBearbeiten { get; set; }

        public decimal GrundDatenLesen { get; set; }

        public decimal HilfetextBearbeiten { get; set; }

        public decimal HilfetextLesen { get; set; }

        public decimal ImportExportSchemataBearbeiten { get; set; }

        public decimal ImportExportSchemataLesen { get; set; }

        public decimal LoginAlsBetrieb { get; set; }

        public decimal LoginAlsGebietskoerperschaft { get; set; }

        public decimal LoginAlsSchule { get; set; }

        public decimal LoginAlsSchulkind { get; set; }

        public decimal NachrichtenBearbeiten { get; set; }

        public decimal NachrichtenLesen { get; set; }

        public decimal NewsletterBearbeiten { get; set; }

        public decimal NewsletterLesen { get; set; }

        public decimal SchuleBearbeiten { get; set; }

        public decimal SchuleLesen { get; set; }

        public decimal SchulkindBearbeiten { get; set; }

        public decimal SchulkindLesen { get; set; }

        public decimal SchulsystemBearbeiten { get; set; }

        public decimal SchulsystemLesen { get; set; }

        public decimal StatistikenBearbeiten { get; set; }

        public decimal StatistikenLesen { get; set; }

        public virtual EfAdminEmailUser AdminEmailUser { get; set; }
    }
}