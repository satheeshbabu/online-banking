import { NgModule, ModuleWithProviders } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DateComponent } from './date/date.component';
import { AuthGuard } from './auth/auth.guard';
import { LeaveComponentGuard } from './deactivation/LeaveComponentGuard';
import { CustomPreloadingStrategy } from './preload/custom-preloading.strategy';

@NgModule({
  imports: [
    FormsModule, // [(ngModel)]
    CommonModule // ngFor, ngIf, ngStyle, ngClass, date, json
  ],
  providers: [],
  declarations: [
    DateComponent
  ],
  exports: [
    DateComponent
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      providers: [AuthGuard, LeaveComponentGuard, CustomPreloadingStrategy],
      ngModule: SharedModule
    };
  }
}
