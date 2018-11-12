import { authConfig } from '../auth.config';
import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isPersonalAccount = false;
  isBusinessAccount = false;
  isCreditCard = false;

  constructor(private oauthService: OAuthService) {
    this.oauthService.configure(authConfig);
    this.oauthService.loadDiscoveryDocument();

    var claims = this.oauthService.getIdentityClaims();

    if (claims && claims['personal_account']) {
      this.isPersonalAccount = true;
    }

    if (claims && claims['business_account']) {
      this.isBusinessAccount = true;
    }

    if (claims && claims['credit_card']) {
      this.isCreditCard = true;
    }
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
