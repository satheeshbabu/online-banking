using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace WayneEnterprises.Authorisation
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityClaimAuthorisation(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, ClaimAuthorisationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, ClaimAuthorisationHandler>();

            return services;
        }

        public static IServiceCollection AddIdentityClaimAuthorisation(this IServiceCollection services, Action<ClaimAuthorisationOptions> options)
        {
            services.Configure(options);

            services.AddSingleton<IAuthorizationPolicyProvider, ClaimAuthorisationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, ClaimAuthorisationHandler>();

            return services;
        }

        public static IServiceCollection AddClientScopeAuthorisation(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, ScopeAuthorisationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, ScopeAuthorisationHandler>();

            return services;
        }

        public static IServiceCollection AddClientScopeAuthorisation(this IServiceCollection services, Action<ScopeAuthorisationOptions> options)
        {
            services.Configure(options);

            services.AddSingleton<IAuthorizationPolicyProvider, ScopeAuthorisationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, ScopeAuthorisationHandler>();

            return services;
        }
    }
}
