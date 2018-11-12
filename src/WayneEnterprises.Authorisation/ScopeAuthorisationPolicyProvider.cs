using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace WayneEnterprises.Authorisation
{
    public class ScopeAuthorisationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly IConfiguration _configuration;
        private readonly AuthorizationOptions _options;

        public ScopeAuthorisationPolicyProvider(
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
                policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new ScopeAuthorisationRequirement(_configuration["Auth0:Domain"], policyName))
                    .Build();

                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }
    }
}