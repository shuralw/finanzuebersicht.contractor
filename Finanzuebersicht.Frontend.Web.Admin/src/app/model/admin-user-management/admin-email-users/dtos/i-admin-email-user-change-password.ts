import { ApiAdminEmailUserChangePassword } from './api/api-admin-email-user-change-password';

export interface IAdminEmailUserChangePassword {
    oldPassword: string;
    newPassword: string;
}

export function toApiAdminEmailUserChangePassword(
    adminEmailUserChangePassword: IAdminEmailUserChangePassword): ApiAdminEmailUserChangePassword {
    return {
        oldPassword: adminEmailUserChangePassword.oldPassword,
        newPassword: adminEmailUserChangePassword.newPassword,
    };
}
