import { ApiAdminEmailUserUpdate } from './api/api-admin-email-user-update';

export interface IAdminEmailUserUpdate {
    id: string;
    email: string;
}

export function toApiAdminEmailUserUpdate(adminEmailUserUpdate: IAdminEmailUserUpdate): ApiAdminEmailUserUpdate {
    return {
        id: adminEmailUserUpdate.id,
        email: adminEmailUserUpdate.email,
    };
}
