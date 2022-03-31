import { fromApiPermissions, IPermissions } from '../../permissions/dtos/i-permissions';
import { fromApiAdminUserGroup, IAdminUserGroup } from '../../admin-user-groups/dtos/i-admin-user-group';
import { ApiAdminAdUserDetail } from './api/api-admin-ad-user-detail';

export interface IAdminAdUserDetail {
    id: string;
    dn: string;
    permissions: IPermissions;
    calculatedPermissions: IPermissions;
    parentAdminUserGroups: IAdminUserGroup[];
}

export function fromApiAdminAdUserDetail(apiAdminAdUserDetail: ApiAdminAdUserDetail): IAdminAdUserDetail {
    return {
        id: apiAdminAdUserDetail.id,
        dn: apiAdminAdUserDetail.dn,
        permissions: fromApiPermissions(apiAdminAdUserDetail.permissions),
        calculatedPermissions: fromApiPermissions(apiAdminAdUserDetail.calculatedPermissions),
        parentAdminUserGroups: apiAdminAdUserDetail.parentAdminUserGroups
            .map(apiAdminUserGroup => fromApiAdminUserGroup(apiAdminUserGroup)),
    };
}
