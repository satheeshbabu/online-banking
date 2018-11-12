import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Account } from '../../models/account';
import { BusinessAccountService } from '../services/business-account.service';

@Component({
  selector: 'current-account',
  templateUrl: './current-account.component.html',
  styleUrls: ['./current-account.component.css']
})
export class CurrentAccountComponent {
  public account: Account;

  constructor(
    private businessAccountService: BusinessAccountService,
    private oauthService: OAuthService) {
    console.debug('access-token', this.oauthService.getAccessToken());
  }

  ngOnInit(): void {
    this.businessAccountService.current().subscribe(data => {
      this.account = data;
    });
  }
}
