"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.authPasswordFlowConfig = {
    issuer: 'http://localhost:8080/auth/realms/wayne-enterprises',
    redirectUri: window.location.origin + '/index.html',
    silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
    clientId: 'online-banking',
    dummyClientSecret: 'arbitrage',
    scope: 'openid profile email',
    showDebugInformation: true,
    oidc: false,
    requireHttps: false
};
//# sourceMappingURL=auth-password-flow.config.js.map