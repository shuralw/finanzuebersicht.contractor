import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'permissionName'
})
export class PermissionNamePipe implements PipeTransform {

  transform(value: number, ...params: string[]): string {
    switch (value) {
      case 0:
        return (params[0] === 'extended') ? 'Deny - due to not set' : 'Not set';
      case 1:
        return 'Allow';
      case 2:
        return 'Deny';
    }
  }

}
