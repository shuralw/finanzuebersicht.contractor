import { ApiAdminAdUserUpdate } from './api/api-admin-ad-user-update';

export interface IAdminAdUserUpdate {
    id: string;
    dn: string;
}

export function toApiAdminAdUserUpdate(adminAdUserUpdate: IAdminAdUserUpdate): ApiAdminAdUserUpdate {
    return {
        id: adminAdUserUpdate.id,
        dn: adminAdUserUpdate.dn,
    };
}
