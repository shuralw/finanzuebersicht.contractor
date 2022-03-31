import { ApiAdminUserGroup } from './api/api-admin-user-group';

export interface IAdminUserGroup {
    id: string;
    name: string;
}

export function fromApiAdminUserGroup(apiAdminUserGroup: ApiAdminUserGroup): IAdminUserGroup {
    return {
        id: apiAdminUserGroup.id,
        name: apiAdminUserGroup.name,
    };
}
