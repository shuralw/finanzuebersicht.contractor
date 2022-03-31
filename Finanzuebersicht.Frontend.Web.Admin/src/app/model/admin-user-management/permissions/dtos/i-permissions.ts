import { ApiPermissions } from './api/api-permissions';

export interface IPermissions {
    Benutzerverwaltung: number;
    BerichteBearbeiten: number;
    BerichteLesen: number;
    BetriebBearbeiten: number;
    BetriebLesen: number;
    DokumenteBearbeiten: number;
    DokumenteLesen: number;
    GebietskoerperschaftBearbeiten: number;
    GebietskoerperschaftLesen: number;
    GrundDatenBearbeiten: number;
    GrundDatenLesen: number;
    HilfetextBearbeiten: number;
    HilfetextLesen: number;
    ImportExportSchemataBearbeiten: number;
    ImportExportSchemataLesen: number;
    LoginAlsBetrieb: number;
    LoginAlsGebietskoerperschaft: number;
    LoginAlsSchule: number;
    LoginAlsSchulkind: number;
    NachrichtenBearbeiten: number;
    NachrichtenLesen: number;
    NewsletterBearbeiten: number;
    NewsletterLesen: number;
    SchuleBearbeiten: number;
    SchuleLesen: number;
    SchulkindBearbeiten: number;
    SchulkindLesen: number;
    SchulsystemBearbeiten: number;
    SchulsystemLesen: number;
    StatistikenBearbeiten: number;
    StatistikenLesen: number;
}

export function toApiPermissions(permissions: IPermissions): ApiPermissions {
    return {
        Benutzerverwaltung: permissions.Benutzerverwaltung,
        BerichteBearbeiten: permissions.BerichteBearbeiten,
        BerichteLesen: permissions.BerichteLesen,
        BetriebBearbeiten: permissions.BetriebBearbeiten,
        BetriebLesen: permissions.BetriebLesen,
        DokumenteBearbeiten: permissions.DokumenteBearbeiten,
        DokumenteLesen: permissions.DokumenteLesen,
        GebietskoerperschaftBearbeiten: permissions.GebietskoerperschaftBearbeiten,
        GebietskoerperschaftLesen: permissions.GebietskoerperschaftLesen,
        GrundDatenBearbeiten: permissions.GrundDatenBearbeiten,
        GrundDatenLesen: permissions.GrundDatenLesen,
        HilfetextBearbeiten: permissions.HilfetextBearbeiten,
        HilfetextLesen: permissions.HilfetextLesen,
        ImportExportSchemataBearbeiten: permissions.ImportExportSchemataBearbeiten,
        ImportExportSchemataLesen: permissions.ImportExportSchemataLesen,
        LoginAlsBetrieb: permissions.LoginAlsBetrieb,
        LoginAlsGebietskoerperschaft: permissions.LoginAlsGebietskoerperschaft,
        LoginAlsSchule: permissions.LoginAlsSchule,
        LoginAlsSchulkind: permissions.LoginAlsSchulkind,
        NachrichtenBearbeiten: permissions.NachrichtenBearbeiten,
        NachrichtenLesen: permissions.NachrichtenLesen,
        NewsletterBearbeiten: permissions.NewsletterBearbeiten,
        NewsletterLesen: permissions.NewsletterLesen,
        SchuleBearbeiten: permissions.SchuleBearbeiten,
        SchuleLesen: permissions.SchuleLesen,
        SchulkindBearbeiten: permissions.SchulkindBearbeiten,
        SchulkindLesen: permissions.SchulkindLesen,
        SchulsystemBearbeiten: permissions.SchulsystemBearbeiten,
        SchulsystemLesen: permissions.SchulsystemLesen,
        StatistikenBearbeiten: permissions.StatistikenBearbeiten,
        StatistikenLesen: permissions.StatistikenLesen,
    };
}

export function fromApiPermissions(apiPermissions: ApiPermissions): IPermissions {
    return {
        Benutzerverwaltung: apiPermissions.Benutzerverwaltung,
        BerichteBearbeiten: apiPermissions.BerichteBearbeiten,
        BerichteLesen: apiPermissions.BerichteLesen,
        BetriebBearbeiten: apiPermissions.BetriebBearbeiten,
        BetriebLesen: apiPermissions.BetriebLesen,
        DokumenteBearbeiten: apiPermissions.DokumenteBearbeiten,
        DokumenteLesen: apiPermissions.DokumenteLesen,
        GebietskoerperschaftBearbeiten: apiPermissions.GebietskoerperschaftBearbeiten,
        GebietskoerperschaftLesen: apiPermissions.GebietskoerperschaftLesen,
        GrundDatenBearbeiten: apiPermissions.GrundDatenBearbeiten,
        GrundDatenLesen: apiPermissions.GrundDatenLesen,
        HilfetextBearbeiten: apiPermissions.HilfetextBearbeiten,
        HilfetextLesen: apiPermissions.HilfetextLesen,
        ImportExportSchemataBearbeiten: apiPermissions.ImportExportSchemataBearbeiten,
        ImportExportSchemataLesen: apiPermissions.ImportExportSchemataLesen,
        LoginAlsBetrieb: apiPermissions.LoginAlsBetrieb,
        LoginAlsGebietskoerperschaft: apiPermissions.LoginAlsGebietskoerperschaft,
        LoginAlsSchule: apiPermissions.LoginAlsSchule,
        LoginAlsSchulkind: apiPermissions.LoginAlsSchulkind,
        NachrichtenBearbeiten: apiPermissions.NachrichtenBearbeiten,
        NachrichtenLesen: apiPermissions.NachrichtenLesen,
        NewsletterBearbeiten: apiPermissions.NewsletterBearbeiten,
        NewsletterLesen: apiPermissions.NewsletterLesen,
        SchuleBearbeiten: apiPermissions.SchuleBearbeiten,
        SchuleLesen: apiPermissions.SchuleLesen,
        SchulkindBearbeiten: apiPermissions.SchulkindBearbeiten,
        SchulkindLesen: apiPermissions.SchulkindLesen,
        SchulsystemBearbeiten: apiPermissions.SchulsystemBearbeiten,
        SchulsystemLesen: apiPermissions.SchulsystemLesen,
        StatistikenBearbeiten: apiPermissions.StatistikenBearbeiten,
        StatistikenLesen: apiPermissions.StatistikenLesen,
    };
}
