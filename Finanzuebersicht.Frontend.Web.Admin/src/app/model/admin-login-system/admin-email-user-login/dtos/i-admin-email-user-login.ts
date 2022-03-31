import { ApiAdminEmailUserLogin } from './api/api-admin-email-user-login';

export interface IAdminEmailUserLogin {
    email: string;
    passwort: string;
}

export function toApiAdminEmailUserLogin(adminEmailUserLogin: IAdminEmailUserLogin): ApiAdminEmailUserLogin {
    return {
        email: adminEmailUserLogin.email,
        passwort: adminEmailUserLogin.passwort,
    };
}
