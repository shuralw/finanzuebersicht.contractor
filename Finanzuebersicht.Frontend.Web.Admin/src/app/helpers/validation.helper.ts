import { dnRegex, emailRegex, passwordRegex } from './regex.helper';

export function validateEmail(email: string): boolean {
    return emailRegex.test(String(email).toLowerCase());
}

export function validateDn(dn: string): boolean {
    return dnRegex.test(dn);
}

export function validatePassword(password: string): boolean {
    return passwordRegex.test(password);
}
