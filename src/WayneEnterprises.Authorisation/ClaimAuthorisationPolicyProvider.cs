using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WayneEnterprises.Authorisation
{
    public class ClaimAuthorisationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly IConfiguration _configuration;
        private readonly AuthorizationOptions _options;

        public ClaimAuthorisationPolicyProvider(
            IOptions<AuthorizationOptions> options,
            IConfiguration configuration) : base(options)
        {
            _options = options.Value;
            _configuration = configuration;
        }

        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = await base.GetPolicyAsync(policyName);
            if (policy == null)
            {
                var parts = policyName.Split(':');
                if (parts.Length != 2) throw new FormatException("Claim format is invalid; <value>:<type> expected.");

                var claim = new KeyValuePair<string, string>(parts[1], parts[0]);

                policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new ClaimAuthorisationRequirement(_configuration["Keycloak:Authority"], claim))
                    .Build();

                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }
    }
}