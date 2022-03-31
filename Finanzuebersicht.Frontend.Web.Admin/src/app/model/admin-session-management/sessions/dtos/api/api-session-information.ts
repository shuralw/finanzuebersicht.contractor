import { ApiPermissions } from 'src/app/model/admin-user-management/permissions/dtos/api/api-permissions';

export interface ApiSessionInformation {
    id: string;
    username: string;
    expiresOn: Date;
    adminEmailUserId?: string;
    adminAdUserId?: string;
    adminAdGroupIds: string[];
    cachedPermissions: ApiPermissions;
}
