namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions
{
    public interface IEfPermissionsEntry
    {
        decimal Benutzerverwaltung { get; set; }

        decimal BerichteBearbeiten { get; set; }

        decimal BerichteLesen { get; set; }

        decimal BetriebBearbeiten { get; set; }

        decimal BetriebLesen { get; set; }

        decimal DokumenteBearbeiten { get; set; }

        decimal DokumenteLesen { get; set; }

        decimal GebietskoerperschaftBearbeiten { get; set; }

        decimal GebietskoerperschaftLesen { get; set; }

        decimal GrundDatenBearbeiten { get; set; }

        decimal GrundDatenLesen { get; set; }

        decimal HilfetextBearbeiten { get; set; }

        decimal HilfetextLesen { get; set; }

        decimal ImportExportSchemataBearbeiten { get; set; }

        decimal ImportExportSchemataLesen { get; set; }

        decimal LoginAlsBetrieb { get; set; }

        decimal LoginAlsGebietskoerperschaft { get; set; }

        decimal LoginAlsSchule { get; set; }

        decimal LoginAlsSchulkind { get; set; }

        decimal NachrichtenBearbeiten { get; set; }

        decimal NachrichtenLesen { get; set; }

        decimal NewsletterBearbeiten { get; set; }

        decimal NewsletterLesen { get; set; }

        decimal SchuleBearbeiten { get; set; }

        decimal SchuleLesen { get; set; }

        decimal SchulkindBearbeiten { get; set; }

        decimal SchulkindLesen { get; set; }

        decimal SchulsystemBearbeiten { get; set; }

        decimal SchulsystemLesen { get; set; }

        decimal StatistikenBearbeiten { get; set; }

        decimal StatistikenLesen { get; set; }
    }
}