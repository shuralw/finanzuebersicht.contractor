import { ApiPermissions } from '../../../permissions/dtos/api/api-permissions';
import { ApiAdminUserGroup } from '../../../admin-user-groups/dtos/api/api-admin-user-group';

export interface ApiAdminEmailUserDetail {
    id: string;
    email: string;
    permissions: ApiPermissions;
    calculatedPermissions: ApiPermissions;
    parentAdminUserGroups: ApiAdminUserGroup[];
}
