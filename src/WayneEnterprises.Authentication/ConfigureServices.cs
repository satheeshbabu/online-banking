using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WayneEnterprises.Authentication
{
    public static class ConfigureServices
    {
        private const string ResponseType = "code id_token";

        public static IServiceCollection AddResourceOwnerPasswordCredentialsFlow(this IServiceCollection services, Action<OpenIdConnectOptions> options)
        {
            var optionsObject = new OpenIdConnectOptions();

            options(optionsObject);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Authority = optionsObject.Authority;
                x.Audience = optionsObject.Audience;
                x.RequireHttpsMetadata = optionsObject.RequireHttpsMetadata;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            return services;
        }

        public static IServiceCollection AddHybridFlow(this IServiceCollection services, Action<OpenIdConnectOptions> options)
        {
            var optionsObject = new OpenIdConnectOptions();

            options(optionsObject);

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(x =>
            {
                x.SignInScheme = "Cookies";
                x.Authority = optionsObject.Authority;
                x.ClientId = optionsObject.ClientId;
                x.ClientSecret = optionsObject.ClientSecret;
                x.ResponseType = ResponseType;
                x.RequireHttpsMetadata = optionsObject.RequireHttpsMetadata;
                x.SaveTokens = true;
                x.GetClaimsFromUserInfoEndpoint = true;
                x.Scope.AddRange(optionsObject.Scopes);
            });

            return services;
        }

        public static IServiceCollection AddImplicitFlowAuthentication(this IServiceCollection services, Action<OpenIdConnectOptions> options)
        {
            var optionsObject = new OpenIdConnectOptions();

            options(optionsObject);

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(x =>
            {
                x.Authority = optionsObject.Authority;
                x.ClientId = optionsObject.ClientId;
                x.SignedOutRedirectUri = optionsObject.SignedOutRedirectUri;
                x.RequireHttpsMetadata = optionsObject.RequireHttpsMetadata;
                x.SaveTokens = true;
            });

            return services;
        }
    }
}