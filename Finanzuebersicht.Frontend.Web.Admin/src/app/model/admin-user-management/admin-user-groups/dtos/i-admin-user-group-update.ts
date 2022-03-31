import { ApiAdminUserGroupUpdate } from './api/api-admin-user-group-update';

export interface IAdminUserGroupUpdate {
    id: string;
    name: string;
}

export function toApiAdminUserGroupUpdate(adminUserGroupUpdate: IAdminUserGroupUpdate): ApiAdminUserGroupUpdate {
    return {
        id: adminUserGroupUpdate.id,
        name: adminUserGroupUpdate.name,
    };
}
