import { UserType } from '../../user-type';

export interface IMember {
    id: string;
    name?: string;
    userType: UserType;
}
