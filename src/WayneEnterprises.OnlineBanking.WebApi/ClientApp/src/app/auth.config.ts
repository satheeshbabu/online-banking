import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {
  issuer: 'http://localhost:8080/auth/realms/wayne-enterprises',
  redirectUri: window.location.origin + '/index.html',
  silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
  clientId: 'online-banking',
  scope: 'openid profile email',
  silentRefreshTimeout: 5000,
  showDebugInformation: true,
  sessionChecksEnabled: false,
  requireHttps: false
};
