import { ApiAdminEmailUser } from './api/api-admin-email-user';

export interface IAdminEmailUser {
    id: string;
    email: string;
}

export function fromApiAdminEmailUser(apiAdminEmailUser: ApiAdminEmailUser): IAdminEmailUser {
    return {
        id: apiAdminEmailUser.id,
        email: apiAdminEmailUser.email,
    };
}
