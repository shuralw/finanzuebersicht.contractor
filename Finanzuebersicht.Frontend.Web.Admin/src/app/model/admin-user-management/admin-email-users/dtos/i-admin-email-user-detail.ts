import { fromApiPermissions, IPermissions } from '../../permissions/dtos/i-permissions';
import { fromApiAdminUserGroup, IAdminUserGroup } from '../../admin-user-groups/dtos/i-admin-user-group';
import { ApiAdminEmailUserDetail } from './api/api-admin-email-user-detail';

export interface IAdminEmailUserDetail {
    id: string;
    email: string;
    permissions: IPermissions;
    calculatedPermissions: IPermissions;
    parentAdminUserGroups: IAdminUserGroup[];
}

export function fromApiAdminEmailUserDetail(apiAdminEmailUserDetail: ApiAdminEmailUserDetail): IAdminEmailUserDetail {
    return {
        id: apiAdminEmailUserDetail.id,
        email: apiAdminEmailUserDetail.email,
        permissions: fromApiPermissions(apiAdminEmailUserDetail.permissions),
        calculatedPermissions: fromApiPermissions(apiAdminEmailUserDetail.calculatedPermissions),
        parentAdminUserGroups: apiAdminEmailUserDetail.parentAdminUserGroups
            .map(apiAdminUserGroup => fromApiAdminUserGroup(apiAdminUserGroup)),
    };
}
