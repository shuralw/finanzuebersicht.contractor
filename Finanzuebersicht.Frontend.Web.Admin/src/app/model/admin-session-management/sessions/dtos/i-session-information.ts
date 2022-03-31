import { fromApiPermissions, IPermissions } from '../../../admin-user-management/permissions/dtos/i-permissions';
import { ApiSessionInformation } from './api/api-session-information';

export interface ISessionInformation {
    id: string;
    username: string;
    expiresOn: Date;
    adminEmailUserId?: string;
    adminAdUserId?: string;
    adminAdGroupIds: string[];
    permissions: IPermissions;
}

export function fromApiSessionInformation(apiSessionInformation: ApiSessionInformation): ISessionInformation {
    return {
        id: apiSessionInformation.id,
        username: apiSessionInformation.username,
        expiresOn: apiSessionInformation.expiresOn,
        adminEmailUserId: apiSessionInformation.adminEmailUserId,
        adminAdUserId: apiSessionInformation.adminAdUserId,
        adminAdGroupIds: apiSessionInformation.adminAdGroupIds,
        permissions: fromApiPermissions(apiSessionInformation.cachedPermissions),
    };
}
