import { fromApiPermissions, IPermissions } from '../../permissions/dtos/i-permissions';
import { fromApiAdminUserGroup, IAdminUserGroup } from '../../admin-user-groups/dtos/i-admin-user-group';
import { ApiAdminAdGroupDetail } from './api/api-admin-ad-group-detail';

export interface IAdminAdGroupDetail {
    id: string;
    dn: string;
    permissions: IPermissions;
    calculatedPermissions: IPermissions;
    parentAdminUserGroups: IAdminUserGroup[];
}

export function fromApiAdminAdGroupDetail(apiAdminAdGroupDetail: ApiAdminAdGroupDetail): IAdminAdGroupDetail {
    return {
        id: apiAdminAdGroupDetail.id,
        dn: apiAdminAdGroupDetail.dn,
        permissions: fromApiPermissions(apiAdminAdGroupDetail.permissions),
        calculatedPermissions: fromApiPermissions(apiAdminAdGroupDetail.calculatedPermissions),
        parentAdminUserGroups: apiAdminAdGroupDetail.parentAdminUserGroups
            .map(apiAdminUserGroup => fromApiAdminUserGroup(apiAdminUserGroup)),
    };
}
