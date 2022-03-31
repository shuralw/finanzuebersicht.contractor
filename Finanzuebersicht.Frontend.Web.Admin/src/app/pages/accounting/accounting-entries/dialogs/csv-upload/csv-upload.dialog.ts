import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { parseNumber } from 'devextreme/localization';
import * as moment from 'moment';
import { parseCsv } from 'src/app/helpers/csv-helper';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { IAccountingEntryCreate } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry-create';
import { AppEventService } from 'src/app/services/event/app-event.service';

@Component({
  selector: 'app-accounting-csv-upload',
  templateUrl: './csv-upload.dialog.html',
  styleUrls: ['./csv-upload.dialog.scss']
})
export class CsvUploadDialog implements OnInit {
  newAccountingEntries: IAccountingEntryCreate[];
  file: any;

  constructor(
    private accountingEntriesCrudService: AccountingEntriesCrudService,
    private formBuilder: FormBuilder,
    private router: Router,
    private appEventService: AppEventService,
    private dialogRef: MatDialogRef<CsvUploadDialog>) {
  }

  async ngOnInit(): Promise<void> {
  }

  async loadCsvFile(file: File): Promise<void> {
    try {
      this.newAccountingEntries = (await parseCsv(file)).map((entry) => {
        const line: IAccountingEntryCreate = {
          categoryId: null,
          auftragskonto: entry['Auftragskonto'],
          buchungsdatum: entry['Buchungstag'] === '' ? null : new Date(moment(entry['Buchungstag'], 'DD.MM.YYYY').format()),
          valutaDatum: entry['Valutadatum'] === '' ? null : new Date(moment(entry['Valutadatum'], 'DD.MM.YYYY').format()),
          buchungstext: entry['Buchungstext'],
          verwendungszweck: entry['Verwendungszweck'],
          glaeubigerId: entry['Glaeubiger ID'],
          mandatsreferenz: entry['Mandatsreferenz'],
          sammlerreferenz: entry['Sammlerreferenz'],
          lastschriftUrsprungsbetrag: entry['Lastschrift Ursprungsbetrag'] === '' ? null : parseFloat(entry['Lastschrift Ursprungsbetrag'].replace(',', '.')),
          auslagenersatzRuecklastschrift: entry['Auslagenersatz Ruecklastschrift'],
          beguenstigter: entry['Beguenstigter/Zahlungspflichtiger'],
          iban: entry['Kontonummer/IBAN'],
          bic: entry['BIC (SWIFT-Code)'],
          betrag: entry['Betrag'] === '' ? null : parseFloat(entry['Betrag'].replace(',', '.')),
          waehrung: entry['Waehrung'],
          info: entry['Info'],
        };

        return line;
      });
    }
    catch (e) {
      console.log('CSV-Datei konnte nicht gelesen werden: ' + e.message);
      return;
    }
  }

  async submit(): Promise<void> {
    try {
      await this.accountingEntriesCrudService.createAccountingEntries(this.newAccountingEntries);
      this.appEventService.newSuccess('Die CSV Datei wurde importiert.');
    }
    catch (e) {
      this.appEventService.newError('Die CSV Datei konnte nicht importiert werden. Es besteht die Möglichkeit, diesen Fehler zu debuggen,'
        + ' indem in der Datei csv-upload-dialog.html den onClick beim Submit Button auf submit_debug() zu ändern.' + e.message);
      console.log(this.newAccountingEntries);
    }
    this.dialogRef.close();
  }

  async submit_debug(): Promise<void> {
    // Die Finanzübersicht ist zum Zeitpunkt der Erstellung dieser methode noch nicht ausgereift / field tested genug.
    // Diese Methode dient dazu, Fehler in csv-Dateien festzustellen, indem nicht ein gesammelter Aufruf gegen das Backend geschickt wird,
    // sondern n Aufrufe (n = csvLines.Length), die bspw. bei einem Bad Request im Network-Tab nachvollzogen werden können.

    try {
      await this.newAccountingEntries.map((entry) => {
        (this.accountingEntriesCrudService.createAccountingEntry(entry));
      });

      this.appEventService.newSuccess('Die CSV Datei wurde importiert.');
    }
    catch (e) {
      this.appEventService.newError('Die CSV Datei konnte nicht importiert werden. ' + e.message);
    }
    this.dialogRef.close();
  }
}
