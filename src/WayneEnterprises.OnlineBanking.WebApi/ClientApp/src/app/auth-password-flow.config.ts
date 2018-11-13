import { AuthConfig } from 'angular-oauth2-oidc';

export const authPasswordFlowConfig: AuthConfig = {
  issuer: 'https://192.168.99.100:30182/auth/realms/wayne-enterprises',
  redirectUri: window.location.origin + '/index.html',
  silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
  clientId: 'online-banking',
  dummyClientSecret: 'arbitrage',
  scope: 'openid profile email',
  showDebugInformation: true,
  oidc: false,
  requireHttps: false
};
