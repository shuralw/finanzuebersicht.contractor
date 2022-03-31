import { ApiPermissions } from '../../../permissions/dtos/api/api-permissions';
import { ApiAdminUserGroup } from '../../../admin-user-groups/dtos/api/api-admin-user-group';

export interface ApiAdminAdGroupDetail {
    id: string;
    dn: string;
    permissions: ApiPermissions;
    calculatedPermissions: ApiPermissions;
    parentAdminUserGroups: ApiAdminUserGroup[];
}
