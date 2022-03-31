import { ApiAdminAdGroup } from './api/api-admin-ad-group';

export interface IAdminAdGroup {
    id: string;
    dn: string;
}

export function fromApiAdminAdGroup(apiAdminAdGroup: ApiAdminAdGroup): IAdminAdGroup {
    return {
        id: apiAdminAdGroup.id,
        dn: apiAdminAdGroup.dn,
    };
}
