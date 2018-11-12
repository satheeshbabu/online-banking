import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { OAuthService } from 'angular-oauth2-oidc';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { BASE_URL } from '../../app.tokens';
import { Account } from '../../models/account';

const ACCOUNT_API: string = '/api/account/business';

@Injectable()
export class BusinessAccountService {
  constructor(
    private http: Http,
    @Inject(BASE_URL) private baseUrl: string,
    private oauthService: OAuthService) { }

  current(): Observable<Account> {
    let url = this.baseUrl + ACCOUNT_API;

    var headers = new Headers({
      "Authorization": "Bearer " + this.oauthService.getAccessToken()
    });

    return this.http
      .get(url, { headers: headers })
      .map((response: Response) => response.json());
  }
}
