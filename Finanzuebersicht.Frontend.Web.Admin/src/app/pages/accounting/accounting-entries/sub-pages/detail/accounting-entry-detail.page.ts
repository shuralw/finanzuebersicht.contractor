import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { IAccountingEntryDetail } from 'src/app/model/accounting/accounting-entries/dtos/i-accounting-entry-detail';
import { AccountingEntryUpdateDialog } from '../../dialogs/update/accounting-entry-update.dialog';

@Component({
  selector: 'app-accounting-entry-detail',
  templateUrl: './accounting-entry-detail.page.html',
  styleUrls: ['./accounting-entry-detail.page.scss']
})
export class AccountingEntryDetailPage implements OnInit {

  accountingEntryId: string;
  accountingEntry: IAccountingEntryDetail;

  constructor(
    private accountingEntriesCrudService: AccountingEntriesCrudService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private matDialog: MatDialog,
    private confirmationDialogService: ConfirmationDialogService) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.accountingEntryId = params.id;
        this.loadAccountingEntry().then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    const dialog = this.matDialog.open(AccountingEntryUpdateDialog, {
        data: this.accountingEntryId,
        minWidth: '320px',
    });

    if (await dialog.afterClosed().toPromise()) {
      await this.loadAccountingEntry();
    }
  }

  async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation('Wollen Sie die Buchung wirklich löschen?')) {
        await this.accountingEntriesCrudService.deleteAccountingEntry(this.accountingEntry.id);
        await this.router.navigate(['/accounting/accounting-entries']);
    }
  }

  private async loadAccountingEntry(): Promise<void> {
    this.accountingEntry = null;
    this.accountingEntry = await this.accountingEntriesCrudService.getAccountingEntryDetail(this.accountingEntryId);
  }

}
