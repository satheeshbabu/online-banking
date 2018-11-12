import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { CurrentAccountComponent } from './current-account/current-account.component';

import { CreditCardRouterModule } from './credit-card.routes';
import { CreditCardComponent } from './credit-card.component';
import { CreditCardService } from './services/credit-card.service';

@NgModule({
  declarations: [
    CreditCardComponent,
    CurrentAccountComponent
  ],
  imports: [
    CommonModule,
    HttpModule,
    CreditCardRouterModule
  ],
  exports: [
    CreditCardComponent
  ],
  providers: [
    CreditCardService
  ]
})
export class CreditCardModule {}
