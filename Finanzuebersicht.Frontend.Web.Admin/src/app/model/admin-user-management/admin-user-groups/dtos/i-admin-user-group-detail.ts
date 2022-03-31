import { fromApiAdminAdGroup, IAdminAdGroup } from '../../admin-ad-groups/dtos/i-admin-ad-group';
import { fromApiAdminAdUser, IAdminAdUser } from '../../admin-ad-users/dtos/i-admin-ad-user';
import { fromApiAdminEmailUser, IAdminEmailUser } from '../../admin-email-users/dtos/i-admin-email-user';
import { fromApiPermissions, IPermissions } from '../../permissions/dtos/i-permissions';
import { ApiAdminUserGroupDetail } from './api/api-admin-user-group-detail';
import { fromApiAdminUserGroup, IAdminUserGroup } from './i-admin-user-group';

export interface IAdminUserGroupDetail {
    id: string;
    name: string;
    permissions: IPermissions;
    calculatedPermissions: IPermissions;
    parentAdminUserGroups: IAdminUserGroup[];
    adminEmailUserMembers: IAdminEmailUser[];
    adminUserGroupMembers: IAdminUserGroup[];
    adminAdUserMembers: IAdminAdUser[];
    adminAdGroupMembers: IAdminAdGroup[];
}

export function fromApiAdminUserGroupDetail(apiAdminUserGroupDetail: ApiAdminUserGroupDetail): IAdminUserGroupDetail {
    return {
        id: apiAdminUserGroupDetail.id,
        name: apiAdminUserGroupDetail.name,
        permissions: fromApiPermissions(apiAdminUserGroupDetail.permissions),
        calculatedPermissions: fromApiPermissions(apiAdminUserGroupDetail.calculatedPermissions),
        parentAdminUserGroups: apiAdminUserGroupDetail.parentAdminUserGroups
            .map(apiAdminUserGroup => fromApiAdminUserGroup(apiAdminUserGroup)),
        adminEmailUserMembers: apiAdminUserGroupDetail.adminEmailUserMembers
            .map(apiAdminEmailUserMember => fromApiAdminEmailUser(apiAdminEmailUserMember)),
        adminUserGroupMembers: apiAdminUserGroupDetail.adminUserGroupMembers
            .map(apiAdminUserGroup => fromApiAdminUserGroup(apiAdminUserGroup)),
        adminAdUserMembers: apiAdminUserGroupDetail.adminAdUserMembers
            .map(apiAdminAdUserMember => fromApiAdminAdUser(apiAdminAdUserMember)),
        adminAdGroupMembers: apiAdminUserGroupDetail.adminAdGroupMembers
            .map(apiAdminAdGroupMember => fromApiAdminAdGroup(apiAdminAdGroupMember)),
    };
}
