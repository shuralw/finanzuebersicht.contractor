import { ApiAdminAdGroupUpdate } from './api/api-admin-ad-group-update';

export interface IAdminAdGroupUpdate {
    id: string;
    dn: string;
}

export function toApiAdminAdGroupUpdate(adminAdGroupUpdate: IAdminAdGroupUpdate): ApiAdminAdGroupUpdate {
    return {
        id: adminAdGroupUpdate.id,
        dn: adminAdGroupUpdate.dn,
    };
}
