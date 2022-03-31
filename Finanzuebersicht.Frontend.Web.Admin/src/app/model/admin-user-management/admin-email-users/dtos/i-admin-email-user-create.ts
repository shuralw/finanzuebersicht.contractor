import { ApiAdminEmailUserCreate } from './api/api-admin-email-user-create';

export interface IAdminEmailUserCreate {
    email: string;
}

export function toApiAdminEmailUserCreate(adminEmailUserCreate: IAdminEmailUserCreate): ApiAdminEmailUserCreate {
    return {
        email: adminEmailUserCreate.email,
    };
}
