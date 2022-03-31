import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialog } from './confirmation-dialog.component';

@Injectable()
export class ConfirmationDialogService {

  constructor(private dialog: MatDialog) { }

  public async askForConfirmation(message?: string, ok?: string, cancel?: string): Promise<boolean> {
    const dialogRef = this.dialog.open(ConfirmationDialog, {
      data: {
        message,
        buttonText: {
          ok,
          cancel
        }
      }
    });

    return await dialogRef.afterClosed().toPromise();
  }

}
