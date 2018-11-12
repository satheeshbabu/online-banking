import { Routes, RouterModule } from '@angular/router';
import { CurrentAccountComponent } from './current-account/current-account.component';
import { SavingsAccountComponent } from './savings-account/savings-account.component';
import { PersonalAccountComponent } from './personal-account.component';
import { AuthGuard } from '../shared/auth/auth.guard';
import { LeaveComponentGuard } from '../shared/deactivation/LeaveComponentGuard';

let PERSONAL_ACCOUNT_ROUTES: Routes = [
  {
    path: '',
    component: PersonalAccountComponent,
    canActivate: [AuthGuard],
    children: [{
      path: 'current-account',
      component: CurrentAccountComponent
    },
    {
      path: 'savings-account',
      component: SavingsAccountComponent
    }]
  }
];

export let PersonalAccountRouterModule = RouterModule.forChild(
  PERSONAL_ACCOUNT_ROUTES
);
