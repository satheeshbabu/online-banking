using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WayneEnterprises.Authorisation
{
    public class ClaimAuthorisationRequirement : IAuthorizationRequirement
    {
        public ClaimAuthorisationRequirement(string issuer, KeyValuePair<string, string> claim)
        {
            if (claim.Key == null || claim.Value == null) throw new ArgumentNullException(nameof(claim));
            
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
            Claim = claim;
        }

        public string Issuer { get; }
        public KeyValuePair<string, string> Claim { get; }
    }
}