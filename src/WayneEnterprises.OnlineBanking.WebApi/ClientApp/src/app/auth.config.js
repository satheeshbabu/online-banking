"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.authConfig = {
    issuer: 'https://192.168.99.100:30182/auth/realms/wayne-enterprises',
    redirectUri: window.location.origin + '/index.html',
    silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',
    clientId: 'online-banking',
    scope: 'openid profile email',
    silentRefreshTimeout: 5000,
    showDebugInformation: true,
    sessionChecksEnabled: false,
    requireHttps: false
};
//# sourceMappingURL=auth.config.js.map