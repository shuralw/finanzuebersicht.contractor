import { Pipe, PipeTransform } from '@angular/core';
import { UserType } from 'src/app/model/admin-user-management/user-type';

@Pipe({
  name: 'userType'
})
export class UserTypePipe implements PipeTransform {

  transform(value: number): string {
    switch (value) {
      case UserType.AdminEmailUser:
        return 'E-Mail-Benutzer';
      case UserType.AdminUserGroup:
        return 'Gruppe';
      case UserType.AdminAdUser:
        return 'AD-Benutzer';
      case UserType.AdminAdGroup:
        return 'AD-Gruppe';
    }
  }

}
