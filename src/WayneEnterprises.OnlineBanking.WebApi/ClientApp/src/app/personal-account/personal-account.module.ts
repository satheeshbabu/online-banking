import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { CurrentAccountComponent } from './current-account/current-account.component';
import { SavingsAccountComponent } from './savings-account/savings-account.component';

import { PersonalAccountRouterModule } from './personal-account.routes';
import { PersonalAccountComponent } from './personal-account.component';
import { PersonalAccountService } from './services/personal-account.service';

@NgModule({
  declarations: [
    PersonalAccountComponent,
    CurrentAccountComponent,
    SavingsAccountComponent
  ],
  imports: [
    CommonModule,
    HttpModule,
    PersonalAccountRouterModule
  ],
  exports: [
    PersonalAccountComponent
  ],
  providers: [
    PersonalAccountService
  ]
})
export class PersonalAccountModule {}
