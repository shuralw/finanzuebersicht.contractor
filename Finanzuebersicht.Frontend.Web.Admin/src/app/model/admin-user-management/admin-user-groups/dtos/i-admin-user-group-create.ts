import { ApiAdminUserGroupCreate } from './api/api-admin-user-group-create';

export interface IAdminUserGroupCreate {
    name: string;
}

export function toApiAdminUserGroupCreate(adminUserGroupCreate: IAdminUserGroupCreate): ApiAdminUserGroupCreate {
    return {
        name: adminUserGroupCreate.name,
    };
}
