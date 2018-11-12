import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { CurrentAccountComponent } from './current-account/current-account.component';

import { BusinessAccountRouterModule } from './business-account.routes';
import { BusinessAccountComponent } from './business-account.component';
import { BusinessAccountService } from './services/business-account.service';

@NgModule({
  declarations: [
    BusinessAccountComponent,
    CurrentAccountComponent
  ],
  imports: [
    CommonModule,
    HttpModule,
    BusinessAccountRouterModule
  ],
  exports: [
    BusinessAccountComponent
  ],
  providers: [
    BusinessAccountService
  ]
})
export class BusinessAccountModule {}
