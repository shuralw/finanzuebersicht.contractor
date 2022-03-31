import { IEnvironment } from './environment.interface';

// tslint:disable: no-string-literal
export const environment: IEnvironment = {
  production: true,
  backendCoreBaseUrl: window['env']['backendCoreBaseUrl'],
  ssoWebserviceBaseUrl: window['env']['ssoWebserviceBaseUrl']
};
