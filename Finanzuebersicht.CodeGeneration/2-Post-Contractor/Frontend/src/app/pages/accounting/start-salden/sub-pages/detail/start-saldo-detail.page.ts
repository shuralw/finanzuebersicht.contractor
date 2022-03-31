import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/components/ui/confirmation-dialog/confirmation-dialog.service';
import { IStartSaldoDetail } from 'src/app/model/accounting/start-salden/dtos/i-start-saldo-detail';
import { StartSaldenCrudService } from 'src/app/model/accounting/start-salden/start-salden-crud.service';
import { StartSaldoUpdateDialog } from '../../dialogs/update/start-saldo-update.dialog';

@Component({
  selector: 'app-start-saldo-detail',
  templateUrl: './start-saldo-detail.page.html',
  styleUrls: ['./start-saldo-detail.page.scss']
})
export class StartSaldoDetailPage implements OnInit {

  startSaldoId: string;
  startSaldo: IStartSaldoDetail;

  constructor(
    private startSaldenCrudService: StartSaldenCrudService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private matDialog: MatDialog,
    private confirmationDialogService: ConfirmationDialogService) {
  }

  async ngOnInit(): Promise<void> {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id) {
        this.startSaldoId = params.id;
        this.loadStartSaldo().then().catch((error) => {
          console.error(error);
        });
      }
    });
  }

  async onUpdateClicked(): Promise<void> {
    const dialog = this.matDialog.open(StartSaldoUpdateDialog, {
        data: this.startSaldoId,
        minWidth: '320px',
    });

    if (await dialog.afterClosed().toPromise()) {
      await this.loadStartSaldo();
    }
  }

  async onDeleteClicked(): Promise<void> {
    if (await this.confirmationDialogService.askForConfirmation('Wollen Sie wirklich Start Saldo \'' + this.startSaldo.bezeichnung + '\' löschen?')) {
        await this.startSaldenCrudService.deleteStartSaldo(this.startSaldo.id);
        await this.router.navigate(['/accounting/start-salden']);
    }
  }

  private async loadStartSaldo(): Promise<void> {
    this.startSaldo = null;
    this.startSaldo = await this.startSaldenCrudService.getStartSaldoDetail(this.startSaldoId);
  }

}
