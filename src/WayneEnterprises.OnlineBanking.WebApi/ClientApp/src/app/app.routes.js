"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var home_component_1 = require("./home/home.component");
var counter_component_1 = require("./counter/counter.component");
var fetch_data_component_1 = require("./fetch-data/fetch-data.component");
var password_flow_login_component_1 = require("./password-flow-login/password-flow-login.component");
var custom_preloading_strategy_1 = require("./shared/preload/custom-preloading.strategy");
var APP_ROUTES = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: home_component_1.HomeComponent
    },
    {
        path: 'counter',
        component: counter_component_1.CounterComponent
    },
    {
        path: 'fetch-data',
        component: fetch_data_component_1.FetchDataComponent
    },
    {
        path: 'password-flow-login',
        component: password_flow_login_component_1.PasswordFlowLoginComponent
    },
    {
        path: 'personal-account',
        loadChildren: './personal-account/personal-account.module#PersonalAccountModule'
    },
    {
        path: 'business-account',
        loadChildren: './business-account/business-account.module#BusinessAccountModule'
    },
    {
        path: 'credit-card',
        loadChildren: './credit-card/credit-card.module#CreditCardModule'
    },
    {
        path: '**',
        redirectTo: 'home'
    }
];
exports.AppRouterModule = router_1.RouterModule.forRoot(APP_ROUTES, {
    preloadingStrategy: custom_preloading_strategy_1.CustomPreloadingStrategy
    // useHash: true,
    // initialNavigation: false
});
//# sourceMappingURL=app.routes.js.map