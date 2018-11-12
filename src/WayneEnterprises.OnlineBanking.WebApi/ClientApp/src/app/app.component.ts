import { authConfig } from "./auth.config";
import { Component } from "@angular/core";
import { OAuthService, JwksValidationHandler } from "angular-oauth2-oidc";
import { filter } from "rxjs/operators";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "app";

  constructor(private oauthService: OAuthService) {
    this.oauthService.configure(authConfig);
    this.oauthService.setStorage(localStorage);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
    this.oauthService.setupAutomaticSilentRefresh();

    this.oauthService.events.subscribe(e => {
      // tslint:disable-next-line:no-console
      console.debug("oauth/oidc event", e);
    });

    this.oauthService.events
      .pipe(filter(e => e.type === "session_terminated"))
      .subscribe(e => {
        // tslint:disable-next-line:no-console
        console.debug("Your session has been terminated!");
      });

    this.oauthService.events
      .pipe(filter(e => e.type === "token_received"))
      .subscribe(e => {
        // this.oauthService.loadUserProfile();
      });
  }
}
