import { NgModule } from '@angular/core';
import { AccountingEntriesCrudService } from 'src/app/model/accounting/accounting-entries/accounting-entries-crud.service';
import { UploadComponent } from './upload.component';


@NgModule({
    declarations: [
        UploadComponent,
    ],
    exports: [
        UploadComponent,
    ],
    providers: [
        AccountingEntriesCrudService
    ]
})
export class UploadComponentsModule { }
