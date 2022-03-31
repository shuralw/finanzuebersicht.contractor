using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUserPasswordReset;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.AdminUserManagement.Permissions;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Ausbildungspartner.Betriebe;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Ausbildungspartner.Betriebskontakte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Ausbildungspartner.Betriebtypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Ausbildungspartner.FilialeKontaktZuordnungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Ausbildungspartner.Filialen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Berufswesen.Berufe;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Bildersystem.Bilder;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BildungsSortiment.BildungsangebotDokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BildungsSortiment.Bildungsangebote;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BildungsSortiment.BildungsangebotGruppen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BildungsSortiment.Klassen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BildungsSortiment.SonderAnmeldezeitraeume;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BildungsSortiment.Varianten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Bildungsverzeichnis.Bildungsgaenge;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Bildungsverzeichnis.Stichworte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Bildungsverzeichnis.Zeitmodelle;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BundeslaenderWerteobjekte.BundeslandGeschlechtTexte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BundeslaenderWerteobjekte.Geschlechter;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BundeslaenderWerteobjekte.KonfessionBlMappings;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BundeslaenderWerteobjekte.Konfessionen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.BundeslandVerwaltung.Bundeslaender;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Datenschutz.Datenschutzbeauftragte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Dokumentensystem.Dokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.AkademischeGrade;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.Anreden;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.Orte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.Postleitzahlen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.PostleitzahlOrtZuordnungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.Sprachen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.Staaten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.GlobaleWerteobjekte.SystemTypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Hochschulwesen.Studienabschluesse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kindesvertretung.Notfallkontakte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kindesvertretung.NotfallkontaktRollen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kindesvertretung.Sorgeberechtigte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kindesvertretung.SorgerechtArten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kindesvertretung.SorgerechtRollen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.Gemeinden;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.GkFeatureAktivierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.GkFeatures;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.GkMandanten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.GkTexte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.GkTypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.GkTypSchulgliederungErlaubnisse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.Kreise;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.Regierungsbezirke;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Kommunalgliederung.Texttypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.BeruflicheKenntnisse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.BeruflicheKenntnisseBlMappings;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.SchulischeAbschluesse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.SchulischerAbschlussBlMappings;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.SgBeruflicheVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.SgSchulischeVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.SgSchulischeZiele;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.VariantenBeruflicheVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Qualifikationen.VariantenSchulischeVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchuelerVerwaltung.Migrationshintergruende;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchuelerVerwaltung.Schulkinder;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchuelerVerwaltung.SchulkindExportierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchuelerVerwaltung.SchulkindhistorienEintraege;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchuelerVerwaltung.SchulkindTypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.Anmeldestatusse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.AnmeldungDokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.Anmeldungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.AnmeldungExportierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.AnmeldungHistorienEintraege;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.AnmeldungHistorienSnapshots;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.BundeslandAnmeldestatusTexte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.Umschulungstragende;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulkindAnmeldungen.WartelisteHistorienEintraege;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulpflicht.AfASchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulpflicht.AnmeldungsloseSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulpflicht.AusbildungSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulpflicht.ExterneSchulenSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulpflicht.UntypischeSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.SchuleFilialeVerifizierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.Schulen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.Schulstandorte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.SchulstandortImportierteFilialen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.SchulstandortTemplateDokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.SchulstandortVerwaltungsErlaubnisse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.SchulVerwaltung.Schulverwaltungsprogramme;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.Jahrgaenge;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.LetzteTaetigkeiten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.Schulformen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.Schulgliederungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.Schulstufen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.SchulstufeSchulformZuordnungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Modules.Schulwesen.StandardAnmeldezeitraeume;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminAccessTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminSessionManagement.AdminRefreshTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminAdUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUserPasswordResetTokens;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminEmailUsers;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.AdminUserManagement.AdminUserGroups;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Ausbildungspartner.Betriebe;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Ausbildungspartner.Betriebskontakte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Ausbildungspartner.Betriebtypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Ausbildungspartner.FilialeKontaktZuordnungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Ausbildungspartner.Filialen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Berufswesen.Berufe;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Bildersystem.Bilder;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BildungsSortiment.BildungsangebotDokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BildungsSortiment.Bildungsangebote;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BildungsSortiment.BildungsangebotGruppen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BildungsSortiment.Klassen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BildungsSortiment.SonderAnmeldezeitraeume;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BildungsSortiment.Varianten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Bildungsverzeichnis.Bildungsgaenge;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Bildungsverzeichnis.Stichworte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Bildungsverzeichnis.Zeitmodelle;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BundeslaenderWerteobjekte.BundeslandGeschlechtTexte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BundeslaenderWerteobjekte.Geschlechter;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BundeslaenderWerteobjekte.KonfessionBlMappings;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BundeslaenderWerteobjekte.Konfessionen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.BundeslandVerwaltung.Bundeslaender;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Datenschutz.Datenschutzbeauftragte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Dokumentensystem.Dokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.AkademischeGrade;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.Anreden;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.Orte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.Postleitzahlen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.PostleitzahlOrtZuordnungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.Sprachen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.Staaten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.GlobaleWerteobjekte.SystemTypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Hochschulwesen.Studienabschluesse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kindesvertretung.Notfallkontakte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kindesvertretung.NotfallkontaktRollen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kindesvertretung.Sorgeberechtigte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kindesvertretung.SorgerechtArten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kindesvertretung.SorgerechtRollen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.Gemeinden;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.GkFeatureAktivierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.GkFeatures;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.GkMandanten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.GkTexte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.GkTypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.GkTypSchulgliederungErlaubnisse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.Kreise;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.Regierungsbezirke;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Kommunalgliederung.Texttypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.BeruflicheKenntnisse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.BeruflicheKenntnisseBlMappings;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.SchulischeAbschluesse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.SchulischerAbschlussBlMappings;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.SgBeruflicheVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.SgSchulischeVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.SgSchulischeZiele;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.VariantenBeruflicheVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Qualifikationen.VariantenSchulischeVoraussetzungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchuelerVerwaltung.Migrationshintergruende;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchuelerVerwaltung.Schulkinder;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchuelerVerwaltung.SchulkindExportierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchuelerVerwaltung.SchulkindhistorienEintraege;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchuelerVerwaltung.SchulkindTypen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.Anmeldestatusse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.AnmeldungDokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.Anmeldungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.AnmeldungExportierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.AnmeldungHistorienEintraege;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.AnmeldungHistorienSnapshots;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.BundeslandAnmeldestatusTexte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.Umschulungstragende;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulkindAnmeldungen.WartelisteHistorienEintraege;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulpflicht.AfASchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulpflicht.AnmeldungsloseSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulpflicht.AusbildungSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulpflicht.ExterneSchulenSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulpflicht.UntypischeSchulpflichterfuellungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.SchuleFilialeVerifizierungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.Schulen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.Schulstandorte;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.SchulstandortImportierteFilialen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.SchulstandortTemplateDokumente;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.SchulstandortVerwaltungsErlaubnisse;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.SchulVerwaltung.Schulverwaltungsprogramme;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.Jahrgaenge;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.LetzteTaetigkeiten;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.Schulformen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.Schulgliederungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.Schulstufen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.SchulstufeSchulformZuordnungen;
using Finanzuebersicht.Backend.Admin.Core.Persistence.Tests.Modules.Schulwesen.StandardAnmeldezeitraeume;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tests
{
    public static class InMemoryDbContext
    {
        public static PersistenceDbContext CreatePersistenceDbContextEmpty()
        {
            DbContextOptions<PersistenceDbContext> options;
            var builder = new DbContextOptionsBuilder<PersistenceDbContext>();
            builder.UseInMemoryDatabase("in-memory-db");
            builder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            options = builder.Options;

            PersistenceDbContext persistenceDbContext = PersistenceDbContext.CustomInstantiate(options);
            persistenceDbContext.Database.EnsureDeleted();
            persistenceDbContext.Database.EnsureCreated();

            return persistenceDbContext;
        }

        public static PersistenceDbContext CreatePersistenceDbContextWithDbDefault()
        {
            PersistenceDbContext persistenceDbContext = CreatePersistenceDbContextEmpty();

            // Inserting Test-Data, ordering does not matter, due to missing foreign key checks of mocked DbContext

            // Login System
            persistenceDbContext.AdminEmailUserFailedLoginAttempts.Add(DbAdminEmailUserFailedLoginAttempt.ToEfAdminEmailUserFailedLoginAttempt(DbAdminEmailUserFailedLoginAttemptTest.DbDefault()));
            persistenceDbContext.AdminEmailUserFailedLoginAttempts.Add(DbAdminEmailUserFailedLoginAttempt.ToEfAdminEmailUserFailedLoginAttempt(DbAdminEmailUserFailedLoginAttemptTest.DbDefault2()));
            persistenceDbContext.AdminEmailUserFailedLoginAttempts.Add(DbAdminEmailUserFailedLoginAttempt.ToEfAdminEmailUserFailedLoginAttempt(DbAdminEmailUserFailedLoginAttemptTest.DbDefault3()));

            // Session Management
            persistenceDbContext.AdminRefreshTokens.Add(DbAdminRefreshToken.ToEfAdminRefreshToken(DbAdminRefreshTokenTest.DbDefault()));
            persistenceDbContext.AdminRefreshTokenAdminAdGroupRelations.Add(new EfAdminRefreshTokenAdminAdGroupRelation() { AdminRefreshTokenId = AdminRefreshTokenTestValues.IdDbDefault, AdminAdGroupId = AdminAdGroupTestValues.IdDbDefault });
            persistenceDbContext.AdminRefreshTokens.Add(DbAdminRefreshToken.ToEfAdminRefreshToken(DbAdminRefreshTokenTest.DbDefault2()));
            persistenceDbContext.AdminRefreshTokenAdminAdGroupRelations.Add(new EfAdminRefreshTokenAdminAdGroupRelation() { AdminRefreshTokenId = AdminRefreshTokenTestValues.IdDbDefault2, AdminAdGroupId = AdminAdGroupTestValues.IdDbDefault2 });

            persistenceDbContext.AdminAccessTokens.Add(DbAdminAccessToken.ToEfAdminAccessToken(DbAdminAccessTokenTest.DbDefault()));
            persistenceDbContext.AdminAccessTokenAdminAdGroupRelations.Add(new EfAdminAccessTokenAdminAdGroupRelation() { AdminAccessTokenId = AdminAccessTokenTestValues.IdDbDefault, AdminAdGroupId = AdminAdGroupTestValues.IdDbDefault });
            persistenceDbContext.AdminAccessTokenCachedPermissions.Add(DbPermissionsEntry.ToEfAdminAccessTokenCachedPermissions(AdminAccessTokenTestValues.IdDbDefault, AdminAccessTokenTestValues.CachedPermissionsDbDefault));
            persistenceDbContext.AdminAccessTokens.Add(DbAdminAccessToken.ToEfAdminAccessToken(DbAdminAccessTokenTest.DbDefault2()));
            persistenceDbContext.AdminAccessTokenAdminAdGroupRelations.Add(new EfAdminAccessTokenAdminAdGroupRelation() { AdminAccessTokenId = AdminAccessTokenTestValues.IdDbDefault2, AdminAdGroupId = AdminAdGroupTestValues.IdDbDefault2 });
            persistenceDbContext.AdminAccessTokenCachedPermissions.Add(DbPermissionsEntry.ToEfAdminAccessTokenCachedPermissions(AdminAccessTokenTestValues.IdDbDefault2, AdminAccessTokenTestValues.CachedPermissionsDbDefault));

            // AdminUserManagement
            persistenceDbContext.AdminEmailUsers.Add(DbAdminEmailUser.ToEfAdminEmailUser(DbAdminEmailUserTest.DbDefault()));
            persistenceDbContext.AdminEmailUserPermissions.Add(DbPermissionsEntry.ToEfAdminEmailUserPermissionsEntry(AdminEmailUserTestValues.IdDbDefault, AdminEmailUserTestValues.PermissionsDbDefault));
            persistenceDbContext.AdminEmailUsers.Add(DbAdminEmailUser.ToEfAdminEmailUser(DbAdminEmailUserTest.DbDefault2()));
            persistenceDbContext.AdminEmailUserPermissions.Add(DbPermissionsEntry.ToEfAdminEmailUserPermissionsEntry(AdminEmailUserTestValues.IdDbDefault2, AdminEmailUserTestValues.PermissionsDbDefault2));

            persistenceDbContext.AdminEmailUserPasswordResetTokens.Add(DbAdminEmailUserPasswordResetToken.ToEfAdminEmailUserPasswordResetToken(DbAdminEmailUserPasswordResetTokenTest.DbDefault()));
            persistenceDbContext.AdminEmailUserPasswordResetTokens.Add(DbAdminEmailUserPasswordResetToken.ToEfAdminEmailUserPasswordResetToken(DbAdminEmailUserPasswordResetTokenTest.DbDefault2()));

            persistenceDbContext.AdminUserGroups.Add(DbAdminUserGroup.ToEfAdminUserGroup(DbAdminUserGroupTest.DbDefault()));
            persistenceDbContext.AdminUserGroupPermissions.Add(DbPermissionsEntry.ToEfAdminUserGroupPermissionsEntry(AdminUserGroupTestValues.IdDbDefault, AdminUserGroupTestValues.PermissionsDbDefault));
            persistenceDbContext.AdminUserGroups.Add(DbAdminUserGroup.ToEfAdminUserGroup(DbAdminUserGroupTest.DbDefault2()));
            persistenceDbContext.AdminUserGroupPermissions.Add(DbPermissionsEntry.ToEfAdminUserGroupPermissionsEntry(AdminUserGroupTestValues.IdDbDefault2, AdminUserGroupTestValues.PermissionsDbDefault2));
            persistenceDbContext.AdminUserGroups.Add(DbAdminUserGroup.ToEfAdminUserGroup(DbAdminUserGroupTest.DbDefault3()));
            persistenceDbContext.AdminUserGroupPermissions.Add(DbPermissionsEntry.ToEfAdminUserGroupPermissionsEntry(AdminUserGroupTestValues.IdDbDefault3, AdminUserGroupTestValues.PermissionsDbDefault3));

            persistenceDbContext.AdminAdUsers.Add(DbAdminAdUser.ToEfAdminAdUser(DbAdminAdUserTest.DbDefault()));
            persistenceDbContext.AdminAdUserPermissions.Add(DbPermissionsEntry.ToEfAdminAdUserPermissionsEntry(AdminAdUserTestValues.IdDbDefault, AdminAdUserTestValues.PermissionsDbDefault));
            persistenceDbContext.AdminAdUsers.Add(DbAdminAdUser.ToEfAdminAdUser(DbAdminAdUserTest.DbDefault2()));
            persistenceDbContext.AdminAdUserPermissions.Add(DbPermissionsEntry.ToEfAdminAdUserPermissionsEntry(AdminAdUserTestValues.IdDbDefault2, AdminAdUserTestValues.PermissionsDbDefault2));

            persistenceDbContext.AdminAdGroups.Add(DbAdminAdGroup.ToEfAdminAdGroup(DbAdminAdGroupTest.DbDefault()));
            persistenceDbContext.AdminAdGroupPermissions.Add(DbPermissionsEntry.ToEfAdminAdGroupPermissionsEntry(AdminAdGroupTestValues.IdDbDefault, AdminAdGroupTestValues.PermissionsDbDefault));
            persistenceDbContext.AdminAdGroups.Add(DbAdminAdGroup.ToEfAdminAdGroup(DbAdminAdGroupTest.DbDefault2()));
            persistenceDbContext.AdminAdGroupPermissions.Add(DbPermissionsEntry.ToEfAdminAdGroupPermissionsEntry(AdminAdGroupTestValues.IdDbDefault2, AdminAdGroupTestValues.PermissionsDbDefault2));

            persistenceDbContext.Betriebe.Add(DbBetrieb.ToEfBetrieb(DbBetriebTest.DbDefault()));
            persistenceDbContext.Betriebe.Add(DbBetrieb.ToEfBetrieb(DbBetriebTest.DbDefault2()));

            persistenceDbContext.Betriebskontakte.Add(DbBetriebskontakt.ToEfBetriebskontakt(DbBetriebskontaktTest.DbDefault()));
            persistenceDbContext.Betriebskontakte.Add(DbBetriebskontakt.ToEfBetriebskontakt(DbBetriebskontaktTest.DbDefault2()));

            persistenceDbContext.Betriebtypen.Add(DbBetriebtyp.ToEfBetriebtyp(DbBetriebtypTest.DbDefault()));
            persistenceDbContext.Betriebtypen.Add(DbBetriebtyp.ToEfBetriebtyp(DbBetriebtypTest.DbDefault2()));

            persistenceDbContext.Filialen.Add(DbFiliale.ToEfFiliale(DbFilialeTest.DbDefault()));
            persistenceDbContext.Filialen.Add(DbFiliale.ToEfFiliale(DbFilialeTest.DbDefault2()));
            persistenceDbContext.Filialen.Add(DbFiliale.ToEfFiliale(DbFilialeTest.ForMoreThanOneFilialeTest()));

            persistenceDbContext.FilialeKontaktZuordnungen.Add(DbFilialeKontaktZuordnung.ToEfFilialeKontaktZuordnung(DbFilialeKontaktZuordnungTest.DbDefault()));
            persistenceDbContext.FilialeKontaktZuordnungen.Add(DbFilialeKontaktZuordnung.ToEfFilialeKontaktZuordnung(DbFilialeKontaktZuordnungTest.DbDefault2()));

            persistenceDbContext.Berufe.Add(DbBeruf.ToEfBeruf(DbBerufTest.DbDefault()));
            persistenceDbContext.Berufe.Add(DbBeruf.ToEfBeruf(DbBerufTest.DbDefault2()));

            persistenceDbContext.Bilder.Add(DbBild.ToEfBild(DbBildTest.DbDefault()));
            persistenceDbContext.Bilder.Add(DbBild.ToEfBild(DbBildTest.DbDefault2()));

            persistenceDbContext.Bildungsangebote.Add(DbBildungsangebot.ToEfBildungsangebot(DbBildungsangebotTest.DbDefault()));
            persistenceDbContext.Bildungsangebote.Add(DbBildungsangebot.ToEfBildungsangebot(DbBildungsangebotTest.DbDefault2()));

            persistenceDbContext.BildungsangebotDokumente.Add(DbBildungsangebotDokument.ToEfBildungsangebotDokument(DbBildungsangebotDokumentTest.DbDefault()));
            persistenceDbContext.BildungsangebotDokumente.Add(DbBildungsangebotDokument.ToEfBildungsangebotDokument(DbBildungsangebotDokumentTest.DbDefault2()));

            persistenceDbContext.BildungsangebotGruppen.Add(DbBildungsangebotGruppe.ToEfBildungsangebotGruppe(DbBildungsangebotGruppeTest.DbDefault()));
            persistenceDbContext.BildungsangebotGruppen.Add(DbBildungsangebotGruppe.ToEfBildungsangebotGruppe(DbBildungsangebotGruppeTest.DbDefault2()));

            persistenceDbContext.Klassen.Add(DbKlasse.ToEfKlasse(DbKlasseTest.DbDefault()));
            persistenceDbContext.Klassen.Add(DbKlasse.ToEfKlasse(DbKlasseTest.DbDefault2()));

            persistenceDbContext.SonderAnmeldezeitraeume.Add(DbSonderAnmeldezeitraum.ToEfSonderAnmeldezeitraum(DbSonderAnmeldezeitraumTest.DbDefault()));
            persistenceDbContext.SonderAnmeldezeitraeume.Add(DbSonderAnmeldezeitraum.ToEfSonderAnmeldezeitraum(DbSonderAnmeldezeitraumTest.DbDefault2()));

            persistenceDbContext.Varianten.Add(DbVariante.ToEfVariante(DbVarianteTest.DbDefault()));
            persistenceDbContext.Varianten.Add(DbVariante.ToEfVariante(DbVarianteTest.DbDefault2()));

            persistenceDbContext.Bildungsgaenge.Add(DbBildungsgang.ToEfBildungsgang(DbBildungsgangTest.DbDefault()));
            persistenceDbContext.Bildungsgaenge.Add(DbBildungsgang.ToEfBildungsgang(DbBildungsgangTest.DbDefault2()));

            persistenceDbContext.Stichworte.Add(DbStichwort.ToEfStichwort(DbStichwortTest.DbDefault()));
            persistenceDbContext.Stichworte.Add(DbStichwort.ToEfStichwort(DbStichwortTest.DbDefault2()));

            persistenceDbContext.Zeitmodelle.Add(DbZeitmodell.ToEfZeitmodell(DbZeitmodellTest.DbDefault()));
            persistenceDbContext.Zeitmodelle.Add(DbZeitmodell.ToEfZeitmodell(DbZeitmodellTest.DbDefault2()));

            persistenceDbContext.Geschlechter.Add(DbGeschlecht.ToEfGeschlecht(DbGeschlechtTest.DbDefault()));
            persistenceDbContext.Geschlechter.Add(DbGeschlecht.ToEfGeschlecht(DbGeschlechtTest.DbDefault2()));

            persistenceDbContext.BundeslandGeschlechtTexte.Add(DbBundeslandGeschlechtText.ToEfBundeslandGeschlechtText(DbBundeslandGeschlechtTextTest.DbDefault()));
            persistenceDbContext.BundeslandGeschlechtTexte.Add(DbBundeslandGeschlechtText.ToEfBundeslandGeschlechtText(DbBundeslandGeschlechtTextTest.DbDefault2()));

            persistenceDbContext.Konfessionen.Add(DbKonfession.ToEfKonfession(DbKonfessionTest.DbDefault()));
            persistenceDbContext.Konfessionen.Add(DbKonfession.ToEfKonfession(DbKonfessionTest.DbDefault2()));

            persistenceDbContext.KonfessionBlMappings.Add(DbKonfessionBlMapping.ToEfKonfessionBlMapping(DbKonfessionBlMappingTest.DbDefault()));
            persistenceDbContext.KonfessionBlMappings.Add(DbKonfessionBlMapping.ToEfKonfessionBlMapping(DbKonfessionBlMappingTest.InverseDbDefault()));

            persistenceDbContext.KonfessionBlMappings.Add(DbKonfessionBlMapping.ToEfKonfessionBlMapping(DbKonfessionBlMappingTest.DbDefault2()));
            persistenceDbContext.KonfessionBlMappings.Add(DbKonfessionBlMapping.ToEfKonfessionBlMapping(DbKonfessionBlMappingTest.InverseDbDefault2()));

            persistenceDbContext.Bundeslaender.Add(DbBundesland.ToEfBundesland(DbBundeslandTest.DbDefault()));
            persistenceDbContext.Bundeslaender.Add(DbBundesland.ToEfBundesland(DbBundeslandTest.DbDefault2()));

            persistenceDbContext.Datenschutzbeauftragte.Add(DbDatenschutzbeauftragter.ToEfDatenschutzbeauftragter(DbDatenschutzbeauftragterTest.DbDefault()));
            persistenceDbContext.Datenschutzbeauftragte.Add(DbDatenschutzbeauftragter.ToEfDatenschutzbeauftragter(DbDatenschutzbeauftragterTest.DbDefault2()));

            persistenceDbContext.Dokumente.Add(DbDokument.ToEfDokument(DbDokumentTest.DbDefault()));
            persistenceDbContext.Dokumente.Add(DbDokument.ToEfDokument(DbDokumentTest.DbDefault2()));

            persistenceDbContext.AkademischeGrade.Add(DbAkademischerGrad.ToEfAkademischerGrad(DbAkademischerGradTest.DbDefault()));
            persistenceDbContext.AkademischeGrade.Add(DbAkademischerGrad.ToEfAkademischerGrad(DbAkademischerGradTest.DbDefault2()));

            persistenceDbContext.Anreden.Add(DbAnrede.ToEfAnrede(DbAnredeTest.DbDefault()));
            persistenceDbContext.Anreden.Add(DbAnrede.ToEfAnrede(DbAnredeTest.DbDefault2()));

            persistenceDbContext.Orte.Add(DbOrt.ToEfOrt(DbOrtTest.DbDefault()));
            persistenceDbContext.Orte.Add(DbOrt.ToEfOrt(DbOrtTest.DbDefault2()));

            persistenceDbContext.Postleitzahlen.Add(DbPostleitzahl.ToEfPostleitzahl(DbPostleitzahlTest.DbDefault()));
            persistenceDbContext.Postleitzahlen.Add(DbPostleitzahl.ToEfPostleitzahl(DbPostleitzahlTest.DbDefault2()));

            persistenceDbContext.PostleitzahlOrtZuordnungen.Add(DbPostleitzahlOrtZuordnung.ToEfPostleitzahlOrtZuordnung(DbPostleitzahlOrtZuordnungTest.DbDefault()));
            persistenceDbContext.PostleitzahlOrtZuordnungen.Add(DbPostleitzahlOrtZuordnung.ToEfPostleitzahlOrtZuordnung(DbPostleitzahlOrtZuordnungTest.DbDefault2()));

            persistenceDbContext.Sprachen.Add(DbSprache.ToEfSprache(DbSpracheTest.DbDefault()));
            persistenceDbContext.Sprachen.Add(DbSprache.ToEfSprache(DbSpracheTest.DbDefault2()));

            persistenceDbContext.Staaten.Add(DbStaat.ToEfStaat(DbStaatTest.DbDefault()));
            persistenceDbContext.Staaten.Add(DbStaat.ToEfStaat(DbStaatTest.DbDefault2()));

            persistenceDbContext.SystemTypen.Add(DbSystemTyp.ToEfSystemTyp(DbSystemTypTest.DbDefault()));
            persistenceDbContext.SystemTypen.Add(DbSystemTyp.ToEfSystemTyp(DbSystemTypTest.DbDefault2()));

            persistenceDbContext.Studienabschluesse.Add(DbStudienabschluss.ToEfStudienabschluss(DbStudienabschlussTest.DbDefault()));
            persistenceDbContext.Studienabschluesse.Add(DbStudienabschluss.ToEfStudienabschluss(DbStudienabschlussTest.DbDefault2()));

            persistenceDbContext.SorgerechtRollen.Add(DbSorgerechtRolle.ToEfSorgerechtRolle(DbSorgerechtRolleTest.DbDefault()));
            persistenceDbContext.SorgerechtRollen.Add(DbSorgerechtRolle.ToEfSorgerechtRolle(DbSorgerechtRolleTest.DbDefault2()));

            persistenceDbContext.Sorgeberechtigte.Add(DbSorgeberechtigter.ToEfSorgeberechtigter(DbSorgeberechtigterTest.DbDefault()));
            persistenceDbContext.Sorgeberechtigte.Add(DbSorgeberechtigter.ToEfSorgeberechtigter(DbSorgeberechtigterTest.DbDefault2()));

            persistenceDbContext.Notfallkontakte.Add(DbNotfallkontakt.ToEfNotfallkontakt(DbNotfallkontaktTest.DbDefault()));
            persistenceDbContext.Notfallkontakte.Add(DbNotfallkontakt.ToEfNotfallkontakt(DbNotfallkontaktTest.DbDefault2()));

            persistenceDbContext.NotfallkontaktRollen.Add(DbNotfallkontaktRolle.ToEfNotfallkontaktRolle(DbNotfallkontaktRolleTest.DbDefault()));
            persistenceDbContext.NotfallkontaktRollen.Add(DbNotfallkontaktRolle.ToEfNotfallkontaktRolle(DbNotfallkontaktRolleTest.DbDefault2()));

            persistenceDbContext.SorgerechtArten.Add(DbSorgerechtArt.ToEfSorgerechtArt(DbSorgerechtArtTest.DbDefault()));
            persistenceDbContext.SorgerechtArten.Add(DbSorgerechtArt.ToEfSorgerechtArt(DbSorgerechtArtTest.DbDefault2()));

            persistenceDbContext.GkMandanten.Add(DbGkMandant.ToEfGkMandant(DbGkMandantTest.DbDefault()));
            persistenceDbContext.GkMandanten.Add(DbGkMandant.ToEfGkMandant(DbGkMandantTest.DbDefault2()));

            persistenceDbContext.Gemeinden.Add(DbGemeinde.ToEfGemeinde(DbGemeindeTest.DbDefault()));
            persistenceDbContext.Gemeinden.Add(DbGemeinde.ToEfGemeinde(DbGemeindeTest.DbDefault2()));

            persistenceDbContext.GkFeatures.Add(DbGkFeature.ToEfGkFeature(DbGkFeatureTest.DbDefault()));
            persistenceDbContext.GkFeatures.Add(DbGkFeature.ToEfGkFeature(DbGkFeatureTest.DbDefault2()));

            persistenceDbContext.GkFeatureAktivierungen.Add(DbGkFeatureAktivierung.ToEfGkFeatureAktivierung(DbGkFeatureAktivierungTest.DbDefault()));
            persistenceDbContext.GkFeatureAktivierungen.Add(DbGkFeatureAktivierung.ToEfGkFeatureAktivierung(DbGkFeatureAktivierungTest.DbDefault2()));

            persistenceDbContext.GkTexte.Add(DbGkText.ToEfGkText(DbGkTextTest.DbDefault()));
            persistenceDbContext.GkTexte.Add(DbGkText.ToEfGkText(DbGkTextTest.DbDefault2()));

            persistenceDbContext.GkTypen.Add(DbGkTyp.ToEfGkTyp(DbGkTypTest.DbDefault()));
            persistenceDbContext.GkTypen.Add(DbGkTyp.ToEfGkTyp(DbGkTypTest.DbDefault2()));

            persistenceDbContext.GkTypSchulgliederungErlaubnisse.Add(DbGkTypSchulgliederungErlaubnis.ToEfGkTypSchulgliederungErlaubnis(DbGkTypSchulgliederungErlaubnisTest.DbDefault()));
            persistenceDbContext.GkTypSchulgliederungErlaubnisse.Add(DbGkTypSchulgliederungErlaubnis.ToEfGkTypSchulgliederungErlaubnis(DbGkTypSchulgliederungErlaubnisTest.DbDefault2()));

            persistenceDbContext.Kreise.Add(DbKreis.ToEfKreis(DbKreisTest.DbDefault()));
            persistenceDbContext.Kreise.Add(DbKreis.ToEfKreis(DbKreisTest.DbDefault2()));

            persistenceDbContext.Regierungsbezirke.Add(DbRegierungsbezirk.ToEfRegierungsbezirk(DbRegierungsbezirkTest.DbDefault()));
            persistenceDbContext.Regierungsbezirke.Add(DbRegierungsbezirk.ToEfRegierungsbezirk(DbRegierungsbezirkTest.DbDefault2()));

            persistenceDbContext.Texttypen.Add(DbTexttyp.ToEfTexttyp(DbTexttypTest.DbDefault()));
            persistenceDbContext.Texttypen.Add(DbTexttyp.ToEfTexttyp(DbTexttypTest.DbDefault2()));

            persistenceDbContext.BeruflicheKenntnisse.Add(DbBeruflicheKenntnis.ToEfBeruflicheKenntnis(DbBeruflicheKenntnisTest.DbDefault()));
            persistenceDbContext.BeruflicheKenntnisse.Add(DbBeruflicheKenntnis.ToEfBeruflicheKenntnis(DbBeruflicheKenntnisTest.DbDefault2()));

            persistenceDbContext.BeruflicheKenntnisseBlMappings.Add(DbBeruflicheKenntnisBlMapping.ToEfBeruflicheKenntnisBlMapping(DbBeruflicheKenntnisBlMappingTest.DbDefault()));
            persistenceDbContext.BeruflicheKenntnisseBlMappings.Add(DbBeruflicheKenntnisBlMapping.ToEfBeruflicheKenntnisBlMapping(DbBeruflicheKenntnisBlMappingTest.InverseDbDefault()));

            persistenceDbContext.BeruflicheKenntnisseBlMappings.Add(DbBeruflicheKenntnisBlMapping.ToEfBeruflicheKenntnisBlMapping(DbBeruflicheKenntnisBlMappingTest.DbDefault2()));
            persistenceDbContext.BeruflicheKenntnisseBlMappings.Add(DbBeruflicheKenntnisBlMapping.ToEfBeruflicheKenntnisBlMapping(DbBeruflicheKenntnisBlMappingTest.InverseDbDefault2()));

            persistenceDbContext.SchulischeAbschluesse.Add(DbSchulischerAbschluss.ToEfSchulischerAbschluss(DbSchulischerAbschlussTest.DbDefault()));
            persistenceDbContext.SchulischeAbschluesse.Add(DbSchulischerAbschluss.ToEfSchulischerAbschluss(DbSchulischerAbschlussTest.DbDefault2()));

            persistenceDbContext.SchulischerAbschlussBlMappings.Add(DbSchulischerAbschlussBlMapping.ToEfSchulischerAbschlussBlMapping(DbSchulischerAbschlussBlMappingTest.DbDefault()));
            persistenceDbContext.SchulischerAbschlussBlMappings.Add(DbSchulischerAbschlussBlMapping.ToEfSchulischerAbschlussBlMapping(DbSchulischerAbschlussBlMappingTest.InverseDbDefault()));

            persistenceDbContext.SchulischerAbschlussBlMappings.Add(DbSchulischerAbschlussBlMapping.ToEfSchulischerAbschlussBlMapping(DbSchulischerAbschlussBlMappingTest.DbDefault2()));
            persistenceDbContext.SchulischerAbschlussBlMappings.Add(DbSchulischerAbschlussBlMapping.ToEfSchulischerAbschlussBlMapping(DbSchulischerAbschlussBlMappingTest.InverseDbDefault2()));

            persistenceDbContext.SgBeruflicheVoraussetzungen.Add(DbSgBeruflicheVoraussetzung.ToEfSgBeruflicheVoraussetzung(DbSgBeruflicheVoraussetzungTest.DbDefault()));
            persistenceDbContext.SgBeruflicheVoraussetzungen.Add(DbSgBeruflicheVoraussetzung.ToEfSgBeruflicheVoraussetzung(DbSgBeruflicheVoraussetzungTest.DbDefault2()));

            persistenceDbContext.SgSchulischeVoraussetzungen.Add(DbSgSchulischeVoraussetzung.ToEfSgSchulischeVoraussetzung(DbSgSchulischeVoraussetzungTest.DbDefault()));
            persistenceDbContext.SgSchulischeVoraussetzungen.Add(DbSgSchulischeVoraussetzung.ToEfSgSchulischeVoraussetzung(DbSgSchulischeVoraussetzungTest.DbDefault2()));

            persistenceDbContext.SgSchulischeZiele.Add(DbSgSchulischesZiel.ToEfSgSchulischesZiel(DbSgSchulischesZielTest.DbDefault()));
            persistenceDbContext.SgSchulischeZiele.Add(DbSgSchulischesZiel.ToEfSgSchulischesZiel(DbSgSchulischesZielTest.DbDefault2()));

            persistenceDbContext.VariantenBeruflicheVoraussetzungen.Add(DbVarianteBeruflicheVoraussetzung.ToEfVarianteBeruflicheVoraussetzung(DbVarianteBeruflicheVoraussetzungTest.DbDefault()));
            persistenceDbContext.VariantenBeruflicheVoraussetzungen.Add(DbVarianteBeruflicheVoraussetzung.ToEfVarianteBeruflicheVoraussetzung(DbVarianteBeruflicheVoraussetzungTest.DbDefault2()));

            persistenceDbContext.VariantenSchulischeVoraussetzungen.Add(DbVarianteSchulischeVoraussetzung.ToEfVarianteSchulischeVoraussetzung(DbVarianteSchulischeVoraussetzungTest.DbDefault()));
            persistenceDbContext.VariantenSchulischeVoraussetzungen.Add(DbVarianteSchulischeVoraussetzung.ToEfVarianteSchulischeVoraussetzung(DbVarianteSchulischeVoraussetzungTest.DbDefault2()));

            persistenceDbContext.Migrationshintergruende.Add(DbMigrationshintergrund.ToEfMigrationshintergrund(DbMigrationshintergrundTest.DbDefault()));
            persistenceDbContext.Migrationshintergruende.Add(DbMigrationshintergrund.ToEfMigrationshintergrund(DbMigrationshintergrundTest.DbDefault2()));

            persistenceDbContext.Schulkinder.Add(DbSchulkind.ToEfSchulkind(DbSchulkindTest.DbDefault()));
            persistenceDbContext.Schulkinder.Add(DbSchulkind.ToEfSchulkind(DbSchulkindTest.DbDefault2()));

            persistenceDbContext.SchulkindExportierungen.Add(DbSchulkindExportierung.ToEfSchulkindExportierung(DbSchulkindExportierungTest.DbDefault()));
            persistenceDbContext.SchulkindExportierungen.Add(DbSchulkindExportierung.ToEfSchulkindExportierung(DbSchulkindExportierungTest.DbDefault2()));

            persistenceDbContext.SchulkindTypen.Add(DbSchulkindTyp.ToEfSchulkindTyp(DbSchulkindTypTest.DbDefault()));
            persistenceDbContext.SchulkindTypen.Add(DbSchulkindTyp.ToEfSchulkindTyp(DbSchulkindTypTest.DbDefault2()));

            persistenceDbContext.SchulkindhistorienEintraege.Add(DbSchulkindhistorienEintrag.ToEfSchulkindhistorienEintrag(DbSchulkindhistorienEintragTest.DbDefault()));
            persistenceDbContext.SchulkindhistorienEintraege.Add(DbSchulkindhistorienEintrag.ToEfSchulkindhistorienEintrag(DbSchulkindhistorienEintragTest.DbDefault2()));

            persistenceDbContext.Schulen.Add(DbSchule.ToEfSchule(DbSchuleTest.DbDefault()));
            persistenceDbContext.Schulen.Add(DbSchule.ToEfSchule(DbSchuleTest.DbDefault2()));

            persistenceDbContext.SchuleFilialeVerifizierungen.Add(DbSchuleFilialeVerifizierung.ToEfSchuleFilialeVerifizierung(DbSchuleFilialeVerifizierungTest.DbDefault()));
            persistenceDbContext.SchuleFilialeVerifizierungen.Add(DbSchuleFilialeVerifizierung.ToEfSchuleFilialeVerifizierung(DbSchuleFilialeVerifizierungTest.DbDefault2()));

            persistenceDbContext.Schulstandorte.Add(DbSchulstandort.ToEfSchulstandort(DbSchulstandortTest.DbDefault()));
            persistenceDbContext.Schulstandorte.Add(DbSchulstandort.ToEfSchulstandort(DbSchulstandortTest.DbDefault2()));

            persistenceDbContext.SchulstandortImportierteFilialen.Add(DbSchulstandortImportierteFiliale.ToEfSchulstandortImportierteFiliale(DbSchulstandortImportierteFilialeTest.DbDefault()));
            persistenceDbContext.SchulstandortImportierteFilialen.Add(DbSchulstandortImportierteFiliale.ToEfSchulstandortImportierteFiliale(DbSchulstandortImportierteFilialeTest.DbDefault2()));

            persistenceDbContext.SchulstandortTemplateDokumente.Add(DbSchulstandortTemplateDokument.ToEfSchulstandortTemplateDokument(DbSchulstandortTemplateDokumentTest.DbDefault()));
            persistenceDbContext.SchulstandortTemplateDokumente.Add(DbSchulstandortTemplateDokument.ToEfSchulstandortTemplateDokument(DbSchulstandortTemplateDokumentTest.DbDefault2()));

            persistenceDbContext.Schulverwaltungsprogramme.Add(DbSchulverwaltungsprogramm.ToEfSchulverwaltungsprogramm(DbSchulverwaltungsprogrammTest.DbDefault()));
            persistenceDbContext.Schulverwaltungsprogramme.Add(DbSchulverwaltungsprogramm.ToEfSchulverwaltungsprogramm(DbSchulverwaltungsprogrammTest.DbDefault2()));

            persistenceDbContext.SchulstandortVerwaltungsErlaubnisse.Add(DbSchulstandortVerwaltungsErlaubnis.ToEfSchulstandortVerwaltungsErlaubnis(DbSchulstandortVerwaltungsErlaubnisTest.DbDefault()));
            persistenceDbContext.SchulstandortVerwaltungsErlaubnisse.Add(DbSchulstandortVerwaltungsErlaubnis.ToEfSchulstandortVerwaltungsErlaubnis(DbSchulstandortVerwaltungsErlaubnisTest.DbDefault2()));

            persistenceDbContext.Anmeldestatusse.Add(DbAnmeldestatus.ToEfAnmeldestatus(DbAnmeldestatusTest.DbDefault()));
            persistenceDbContext.Anmeldestatusse.Add(DbAnmeldestatus.ToEfAnmeldestatus(DbAnmeldestatusTest.DbDefault2()));

            persistenceDbContext.Anmeldungen.Add(DbAnmeldung.ToEfAnmeldung(DbAnmeldungTest.DbDefault()));
            persistenceDbContext.Anmeldungen.Add(DbAnmeldung.ToEfAnmeldung(DbAnmeldungTest.DbDefault2()));

            persistenceDbContext.AnmeldungDokumente.Add(DbAnmeldungDokument.ToEfAnmeldungDokument(DbAnmeldungDokumentTest.DbDefault()));
            persistenceDbContext.AnmeldungDokumente.Add(DbAnmeldungDokument.ToEfAnmeldungDokument(DbAnmeldungDokumentTest.DbDefault2()));

            persistenceDbContext.AnmeldungExportierungen.Add(DbAnmeldungExportierung.ToEfAnmeldungExportierung(DbAnmeldungExportierungTest.DbDefault()));
            persistenceDbContext.AnmeldungExportierungen.Add(DbAnmeldungExportierung.ToEfAnmeldungExportierung(DbAnmeldungExportierungTest.DbDefault2()));

            persistenceDbContext.AnmeldungHistorienEintraege.Add(DbAnmeldungHistorienEintrag.ToEfAnmeldungHistorienEintrag(DbAnmeldungHistorienEintragTest.DbDefault()));
            persistenceDbContext.AnmeldungHistorienEintraege.Add(DbAnmeldungHistorienEintrag.ToEfAnmeldungHistorienEintrag(DbAnmeldungHistorienEintragTest.DbDefault2()));

            persistenceDbContext.AnmeldungHistorienSnapshots.Add(DbAnmeldungHistorienSnapshot.ToEfAnmeldungHistorienSnapshot(DbAnmeldungHistorienSnapshotTest.DbDefault()));
            persistenceDbContext.AnmeldungHistorienSnapshots.Add(DbAnmeldungHistorienSnapshot.ToEfAnmeldungHistorienSnapshot(DbAnmeldungHistorienSnapshotTest.DbDefault2()));

            persistenceDbContext.BundeslandAnmeldestatusTexte.Add(DbBundeslandAnmeldestatusText.ToEfBundeslandAnmeldestatusText(DbBundeslandAnmeldestatusTextTest.DbDefault()));
            persistenceDbContext.BundeslandAnmeldestatusTexte.Add(DbBundeslandAnmeldestatusText.ToEfBundeslandAnmeldestatusText(DbBundeslandAnmeldestatusTextTest.DbDefault2()));

            persistenceDbContext.Umschulungstragende.Add(DbUmschulungstragender.ToEfUmschulungstragender(DbUmschulungstragenderTest.DbDefault()));
            persistenceDbContext.Umschulungstragende.Add(DbUmschulungstragender.ToEfUmschulungstragender(DbUmschulungstragenderTest.DbDefault2()));

            persistenceDbContext.WartelisteHistorienEintraege.Add(DbWartelisteHistorienEintrag.ToEfWartelisteHistorienEintrag(DbWartelisteHistorienEintragTest.DbDefault()));
            persistenceDbContext.WartelisteHistorienEintraege.Add(DbWartelisteHistorienEintrag.ToEfWartelisteHistorienEintrag(DbWartelisteHistorienEintragTest.DbDefault2()));

            persistenceDbContext.AfASchulpflichterfuellungen.Add(DbAfASchulpflichterfuellung.ToEfAfASchulpflichterfuellung(DbAfASchulpflichterfuellungTest.DbDefault()));
            persistenceDbContext.AfASchulpflichterfuellungen.Add(DbAfASchulpflichterfuellung.ToEfAfASchulpflichterfuellung(DbAfASchulpflichterfuellungTest.DbDefault2()));

            persistenceDbContext.AnmeldungsloseSchulpflichterfuellungen.Add(DbAnmeldungsloseSchulpflichterfuellung.ToEfAnmeldungsloseSchulpflichterfuellung(DbAnmeldungsloseSchulpflichterfuellungTest.DbDefault()));
            persistenceDbContext.AnmeldungsloseSchulpflichterfuellungen.Add(DbAnmeldungsloseSchulpflichterfuellung.ToEfAnmeldungsloseSchulpflichterfuellung(DbAnmeldungsloseSchulpflichterfuellungTest.DbDefault2()));

            persistenceDbContext.AusbildungSchulpflichterfuellungen.Add(DbAusbildungSchulpflichterfuellung.ToEfAusbildungSchulpflichterfuellung(DbAusbildungSchulpflichterfuellungTest.DbDefault()));
            persistenceDbContext.AusbildungSchulpflichterfuellungen.Add(DbAusbildungSchulpflichterfuellung.ToEfAusbildungSchulpflichterfuellung(DbAusbildungSchulpflichterfuellungTest.DbDefault2()));

            persistenceDbContext.ExterneSchulenSchulpflichterfuellungen.Add(DbExterneSchuleSchulpflichterfuellung.ToEfExterneSchuleSchulpflichterfuellung(DbExterneSchuleSchulpflichterfuellungTest.DbDefault()));
            persistenceDbContext.ExterneSchulenSchulpflichterfuellungen.Add(DbExterneSchuleSchulpflichterfuellung.ToEfExterneSchuleSchulpflichterfuellung(DbExterneSchuleSchulpflichterfuellungTest.DbDefault2()));

            persistenceDbContext.UntypischeSchulpflichterfuellungen.Add(DbUntypischeSchulpflichterfuellung.ToEfUntypischeSchulpflichterfuellung(DbUntypischeSchulpflichterfuellungTest.DbDefault()));
            persistenceDbContext.UntypischeSchulpflichterfuellungen.Add(DbUntypischeSchulpflichterfuellung.ToEfUntypischeSchulpflichterfuellung(DbUntypischeSchulpflichterfuellungTest.DbDefault2()));

            persistenceDbContext.Jahrgaenge.Add(DbJahrgang.ToEfJahrgang(DbJahrgangTest.DbDefault()));
            persistenceDbContext.Jahrgaenge.Add(DbJahrgang.ToEfJahrgang(DbJahrgangTest.DbDefault2()));

            persistenceDbContext.LetzteTaetigkeiten.Add(DbLetzteTaetigkeit.ToEfLetzteTaetigkeit(DbLetzteTaetigkeitTest.DbDefault()));
            persistenceDbContext.LetzteTaetigkeiten.Add(DbLetzteTaetigkeit.ToEfLetzteTaetigkeit(DbLetzteTaetigkeitTest.DbDefault2()));

            persistenceDbContext.Schulformen.Add(DbSchulform.ToEfSchulform(DbSchulformTest.DbDefault()));
            persistenceDbContext.Schulformen.Add(DbSchulform.ToEfSchulform(DbSchulformTest.DbDefault2()));

            persistenceDbContext.Schulgliederungen.Add(DbSchulgliederung.ToEfSchulgliederung(DbSchulgliederungTest.DbDefault()));
            persistenceDbContext.Schulgliederungen.Add(DbSchulgliederung.ToEfSchulgliederung(DbSchulgliederungTest.DbDefault2()));

            persistenceDbContext.Schulstufen.Add(DbSchulstufe.ToEfSchulstufe(DbSchulstufeTest.DbDefault()));
            persistenceDbContext.Schulstufen.Add(DbSchulstufe.ToEfSchulstufe(DbSchulstufeTest.DbDefault2()));

            persistenceDbContext.SchulstufeSchulformZuordnungen.Add(DbSchulstufeSchulformZuordnung.ToEfSchulstufeSchulformZuordnung(DbSchulstufeSchulformZuordnungTest.DbDefault()));
            persistenceDbContext.SchulstufeSchulformZuordnungen.Add(DbSchulstufeSchulformZuordnung.ToEfSchulstufeSchulformZuordnung(DbSchulstufeSchulformZuordnungTest.DbDefault2()));

            persistenceDbContext.StandardAnmeldezeitraeume.Add(DbStandardAnmeldezeitraum.ToEfStandardAnmeldezeitraum(DbStandardAnmeldezeitraumTest.DbDefault()));
            persistenceDbContext.StandardAnmeldezeitraeume.Add(DbStandardAnmeldezeitraum.ToEfStandardAnmeldezeitraum(DbStandardAnmeldezeitraumTest.DbDefault2()));

            persistenceDbContext.SaveChanges();

            return persistenceDbContext;
        }
    }
}