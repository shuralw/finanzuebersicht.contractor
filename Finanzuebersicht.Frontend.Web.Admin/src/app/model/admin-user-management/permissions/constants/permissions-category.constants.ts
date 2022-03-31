import { IPermissionsCategory } from '../dtos/i-permissions-category';

export function emptyPermissionsCategories(): IPermissionsCategory[] {
    return [
        {
            name: 'Benutzerverwaltung',
            permissions: [
                {
                    name: 'Benutzer verwalten',
                    value: null
                }
            ]
        },
        {
            name: 'Systeme-Logins',
            permissions: [
                {
                    name: 'Login als Betrieb',
                    value: null
                },
                {
                    name: 'Login als Gebietskörperschaft',
                    value: null
                },
                {
                    name: 'Login als Schule',
                    value: null
                },
                {
                    name: 'Login als Schulkind',
                    value: null
                }
            ]
        },
        {
            name: 'Systeme',
            permissions: [
                {
                    name: 'Betrieb lesen',
                    value: null
                },
                {
                    name: 'Betrieb bearbeiten',
                    value: null
                },
                {
                    name: 'Gebietskörperschaft lesen',
                    value: null
                },
                {
                    name: 'Gebietskörperschaft bearbeiten',
                    value: null
                },
                {
                    name: 'Schule lesen',
                    value: null
                },
                {
                    name: 'Schule bearbeiten',
                    value: null
                },
                {
                    name: 'Schulkind lesen',
                    value: null
                },
                {
                    name: 'Schulkind bearbeiten',
                    value: null
                }
            ]
        },
        {
            name: 'Globale Stammdaten',
            permissions: [
                {
                    name: 'Schulsystem lesen',
                    value: null
                },
                {
                    name: 'Schulsystem bearbeiten',
                    value: null
                },
                {
                    name: 'Grund-Daten lesen',
                    value: null
                },
                {
                    name: 'Grund-Daten bearbeiten',
                    value: null
                },
                {
                    name: 'Import-Export-Schemata lesen',
                    value: null
                },
                {
                    name: 'Import-Export-Schemata bearbeiten',
                    value: null
                }
            ]
        },
        {
            name: 'Texte',
            permissions: [
                {
                    name: 'Dokumente lesen',
                    value: null
                },
                {
                    name: 'Dokumente bearbeiten',
                    value: null
                },
                {
                    name: 'Hilfetext lesen',
                    value: null
                },
                {
                    name: 'Hilfetext bearbeiten',
                    value: null
                },
                {
                    name: 'Nachrichten lesen',
                    value: null
                },
                {
                    name: 'Nachrichten bearbeiten',
                    value: null
                },
                {
                    name: 'Newsletter lesen',
                    value: null
                },
                {
                    name: 'Newsletter bearbeiten',
                    value: null
                }
            ]
        },
        {
            name: 'Statistik',
            permissions: [
                {
                    name: 'Berichte lesen',
                    value: null
                },
                {
                    name: 'Berichte bearbeiten',
                    value: null
                },
                {
                    name: 'Statistiken lesen',
                    value: null
                },
                {
                    name: 'Statistiken bearbeiten',
                    value: null
                }
            ]
        },
    ];
}
