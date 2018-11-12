import { Routes, RouterModule } from '@angular/router';
import { CurrentAccountComponent } from './current-account/current-account.component';
import { BusinessAccountComponent } from './business-account.component';
import { AuthGuard } from '../shared/auth/auth.guard';
import { LeaveComponentGuard } from '../shared/deactivation/LeaveComponentGuard';

let PERSONAL_ACCOUNT_ROUTES: Routes = [
  {
    path: '',
    component: BusinessAccountComponent,
    canActivate: [AuthGuard],
    children: [{
      path: 'current-account',
      component: CurrentAccountComponent
    }]
  }
];

export let BusinessAccountRouterModule = RouterModule.forChild(
  PERSONAL_ACCOUNT_ROUTES
);
