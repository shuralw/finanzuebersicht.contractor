import { emptyPermissionsCategories } from '../constants/permissions-category.constants';
import { IPermissions } from './i-permissions';

export interface IPermissionsCategory {
    name: string;
    hidden?: boolean;
    permissions: IPermission[];
}

export interface IPermission {
    name: string;
    value: number;
}

export function fromPermissionsCategories(permissionsCategories: IPermissionsCategory[]): IPermissions {
    return {
        Benutzerverwaltung: Number(permissionsCategories[0].permissions[0].value),
        LoginAlsBetrieb: Number(permissionsCategories[1].permissions[0].value),
        LoginAlsGebietskoerperschaft: Number(permissionsCategories[1].permissions[1].value),
        LoginAlsSchule: Number(permissionsCategories[1].permissions[2].value),
        LoginAlsSchulkind: Number(permissionsCategories[1].permissions[3].value),
        BetriebLesen: Number(permissionsCategories[2].permissions[0].value),
        BetriebBearbeiten: Number(permissionsCategories[2].permissions[1].value),
        GebietskoerperschaftLesen: Number(permissionsCategories[2].permissions[2].value),
        GebietskoerperschaftBearbeiten: Number(permissionsCategories[2].permissions[3].value),
        SchuleLesen: Number(permissionsCategories[2].permissions[4].value),
        SchuleBearbeiten: Number(permissionsCategories[2].permissions[5].value),
        SchulkindLesen: Number(permissionsCategories[2].permissions[6].value),
        SchulkindBearbeiten: Number(permissionsCategories[2].permissions[7].value),
        SchulsystemLesen: Number(permissionsCategories[3].permissions[0].value),
        SchulsystemBearbeiten: Number(permissionsCategories[3].permissions[1].value),
        GrundDatenLesen: Number(permissionsCategories[3].permissions[2].value),
        GrundDatenBearbeiten: Number(permissionsCategories[3].permissions[3].value),
        ImportExportSchemataLesen: Number(permissionsCategories[3].permissions[4].value),
        ImportExportSchemataBearbeiten: Number(permissionsCategories[3].permissions[5].value),
        DokumenteLesen: Number(permissionsCategories[4].permissions[0].value),
        DokumenteBearbeiten: Number(permissionsCategories[4].permissions[1].value),
        HilfetextLesen: Number(permissionsCategories[4].permissions[2].value),
        HilfetextBearbeiten: Number(permissionsCategories[4].permissions[3].value),
        NachrichtenLesen: Number(permissionsCategories[4].permissions[4].value),
        NachrichtenBearbeiten: Number(permissionsCategories[4].permissions[5].value),
        NewsletterLesen: Number(permissionsCategories[4].permissions[6].value),
        NewsletterBearbeiten: Number(permissionsCategories[4].permissions[7].value),
        BerichteLesen: Number(permissionsCategories[5].permissions[0].value),
        BerichteBearbeiten: Number(permissionsCategories[5].permissions[1].value),
        StatistikenLesen: Number(permissionsCategories[5].permissions[2].value),
        StatistikenBearbeiten: Number(permissionsCategories[5].permissions[3].value),
    };
}

export function toPermissionsCategories(permissions: IPermissions): IPermissionsCategory[] {
    const permissionsCategories = emptyPermissionsCategories();
    updatePermissionsCategories(permissionsCategories, permissions);
    return permissionsCategories;
}

export function updatePermissionsCategories(permissionsCategories: IPermissionsCategory[], permissions: IPermissions): void {
    // Benutzerverwaltung
    permissionsCategories[0].permissions[0].value = permissions.Benutzerverwaltung;

    // Systeme-Logins
    permissionsCategories[1].permissions[0].value = permissions.LoginAlsBetrieb;
    permissionsCategories[1].permissions[1].value = permissions.LoginAlsGebietskoerperschaft;
    permissionsCategories[1].permissions[2].value = permissions.LoginAlsSchule;
    permissionsCategories[1].permissions[3].value = permissions.LoginAlsSchulkind;

    // Systeme
    permissionsCategories[2].permissions[0].value = permissions.BetriebLesen;
    permissionsCategories[2].permissions[1].value = permissions.BetriebBearbeiten;
    permissionsCategories[2].permissions[2].value = permissions.GebietskoerperschaftLesen;
    permissionsCategories[2].permissions[3].value = permissions.GebietskoerperschaftBearbeiten;
    permissionsCategories[2].permissions[4].value = permissions.SchuleLesen;
    permissionsCategories[2].permissions[5].value = permissions.SchuleBearbeiten;
    permissionsCategories[2].permissions[6].value = permissions.SchulkindLesen;
    permissionsCategories[2].permissions[7].value = permissions.SchulkindBearbeiten;

    // Globale Stammdaten
    permissionsCategories[3].permissions[0].value = permissions.SchulsystemLesen;
    permissionsCategories[3].permissions[1].value = permissions.SchulsystemBearbeiten;
    permissionsCategories[3].permissions[2].value = permissions.GrundDatenLesen;
    permissionsCategories[3].permissions[3].value = permissions.GrundDatenBearbeiten;
    permissionsCategories[3].permissions[4].value = permissions.ImportExportSchemataLesen;
    permissionsCategories[3].permissions[5].value = permissions.ImportExportSchemataBearbeiten;

    // Texte
    permissionsCategories[4].permissions[0].value = permissions.DokumenteLesen;
    permissionsCategories[4].permissions[1].value = permissions.DokumenteBearbeiten;
    permissionsCategories[4].permissions[2].value = permissions.HilfetextLesen;
    permissionsCategories[4].permissions[3].value = permissions.HilfetextBearbeiten;
    permissionsCategories[4].permissions[4].value = permissions.NachrichtenLesen;
    permissionsCategories[4].permissions[5].value = permissions.NachrichtenBearbeiten;
    permissionsCategories[4].permissions[6].value = permissions.NewsletterLesen;
    permissionsCategories[4].permissions[7].value = permissions.NewsletterBearbeiten;

    // Statistik
    permissionsCategories[5].permissions[0].value = permissions.BerichteLesen;
    permissionsCategories[5].permissions[1].value = permissions.BerichteBearbeiten;
    permissionsCategories[5].permissions[2].value = permissions.StatistikenLesen;
    permissionsCategories[5].permissions[3].value = permissions.StatistikenBearbeiten;

}
