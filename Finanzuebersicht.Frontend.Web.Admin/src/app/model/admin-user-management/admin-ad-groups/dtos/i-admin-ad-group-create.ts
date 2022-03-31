import { ApiAdminAdGroupCreate } from './api/api-admin-ad-group-create';

export interface IAdminAdGroupCreate {
    dn: string;
}

export function toApiAdminAdGroupCreate(adminAdGroupCreate: IAdminAdGroupCreate): ApiAdminAdGroupCreate {
    return {
        dn: adminAdGroupCreate.dn,
    };
}
