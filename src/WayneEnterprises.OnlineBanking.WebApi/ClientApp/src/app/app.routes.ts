import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PasswordFlowLoginComponent } from './password-flow-login/password-flow-login.component';
import { CustomPreloadingStrategy } from './shared/preload/custom-preloading.strategy';

let APP_ROUTES: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'counter',
    component: CounterComponent
  },
  {
    path: 'fetch-data',
    component: FetchDataComponent
  },
  {
    path: 'password-flow-login',
    component: PasswordFlowLoginComponent
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

export let AppRouterModule = RouterModule.forRoot(APP_ROUTES, {
  preloadingStrategy: CustomPreloadingStrategy
  // useHash: true,
  // initialNavigation: false
});
