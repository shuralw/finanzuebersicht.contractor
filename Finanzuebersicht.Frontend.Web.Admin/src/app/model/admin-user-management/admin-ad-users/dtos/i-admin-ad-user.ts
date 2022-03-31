import { ApiAdminAdUser } from './api/api-admin-ad-user';

export interface IAdminAdUser {
    id: string;
    dn: string;
}

export function fromApiAdminAdUser(apiAdminAdUser: ApiAdminAdUser): IAdminAdUser {
    return {
        id: apiAdminAdUser.id,
        dn: apiAdminAdUser.dn,
    };
}
