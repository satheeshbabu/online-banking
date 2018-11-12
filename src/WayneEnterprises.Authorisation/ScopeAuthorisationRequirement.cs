using System;
using Microsoft.AspNetCore.Authorization;

namespace WayneEnterprises.Authorisation
{
    public class ScopeAuthorisationRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public ScopeAuthorisationRequirement(string issuer, string scope)
        {
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }
    }
}