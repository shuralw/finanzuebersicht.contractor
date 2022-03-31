import { ApiAdminAdGroup } from '../../../admin-ad-groups/dtos/api/api-admin-ad-group';
import { ApiAdminAdUser } from '../../../admin-ad-users/dtos/api/api-admin-ad-user';
import { ApiAdminEmailUser } from '../../../admin-email-users/dtos/api/api-admin-email-user';
import { ApiPermissions } from '../../../permissions/dtos/api/api-permissions';
import { ApiAdminUserGroup } from './api-admin-user-group';

export interface ApiAdminUserGroupDetail {
    id: string;
    name: string;
    permissions: ApiPermissions;
    calculatedPermissions: ApiPermissions;
    parentAdminUserGroups: ApiAdminUserGroup[];
    adminEmailUserMembers: ApiAdminEmailUser[];
    adminUserGroupMembers: ApiAdminUserGroup[];
    adminAdUserMembers: ApiAdminAdUser[];
    adminAdGroupMembers: ApiAdminAdGroup[];
}
