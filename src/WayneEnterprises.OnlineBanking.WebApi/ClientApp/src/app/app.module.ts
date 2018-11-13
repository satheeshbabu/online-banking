import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { OAuthModule } from "angular-oauth2-oidc";
import { AppComponent } from "./app.component";
import { AppRouterModule } from "./app.routes";
import { BASE_URL } from "./app.tokens";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { PasswordFlowLoginComponent } from "./password-flow-login/password-flow-login.component";
import { SharedModule } from "./shared/shared.module";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PasswordFlowLoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule.forRoot(),
    AppRouterModule,
    HttpClientModule,
    OAuthModule.forRoot()
  ],
  providers: [
    { provide: BASE_URL, useValue: "https://onlinebanking.wayne.enterprises" }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
