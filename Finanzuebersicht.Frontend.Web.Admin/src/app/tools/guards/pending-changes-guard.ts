import { CanDeactivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface ComponentCanDeactivate {
    canDeactivate: () => boolean | Observable<boolean>;
}

@Injectable()
export class PendingChangesGuard implements CanDeactivate<ComponentCanDeactivate> {

    public static readonly WarningMessage: string =
        'Beim Verlassen der Seite werden Ihre Änderungen eventuell nicht gespeichert.';

    canDeactivate(component: ComponentCanDeactivate): boolean | Observable<boolean> {
        return component.canDeactivate() ?
            true :
            confirm(PendingChangesGuard.WarningMessage);
    }
}
