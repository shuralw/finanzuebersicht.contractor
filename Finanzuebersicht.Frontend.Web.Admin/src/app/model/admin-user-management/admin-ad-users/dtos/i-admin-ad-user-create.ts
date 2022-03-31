import { ApiAdminAdUserCreate } from './api/api-admin-ad-user-create';

export interface IAdminAdUserCreate {
    dn: string;
}

export function toApiAdminAdUserCreate(adminAdUserCreate: IAdminAdUserCreate): ApiAdminAdUserCreate {
    return {
        dn: adminAdUserCreate.dn,
    };
}
