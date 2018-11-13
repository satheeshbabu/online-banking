import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'http://192.168.99.100:30181/auth/realms/wayne-enterprises',
  redirectUri: window.location.origin + '/index.html',
  silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
  clientId: 'online-banking',
  scope: 'openid profile email',
  showDebugInformation: true,
  sessionChecksEnabled: false,
  requireHttps: false
};
