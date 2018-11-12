import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { Account } from '../../models/account';
import { PersonalAccountService } from '../services/personal-account.service';

@Component({
  selector: 'savings-account',
  templateUrl: './savings-account.component.html',
  styleUrls: ['./savings-account.component.css']
})
export class SavingsAccountComponent {
  public account: Account;

  constructor(
    private personalAccountService: PersonalAccountService,
    private oauthService: OAuthService) {
    console.debug('access-token', this.oauthService.getAccessToken());
  }

  ngOnInit(): void {
    this.personalAccountService.savings().subscribe(data => {
      this.account = data;
    });
  }
}
