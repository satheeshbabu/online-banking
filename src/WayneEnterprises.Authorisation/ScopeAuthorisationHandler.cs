using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace WayneEnterprises.Authorisation
{
    public class ScopeAuthorisationHandler : AuthorizationHandler<ScopeAuthorisationRequirement>
    {
        public ScopeAuthorisationHandler(IOptions<ScopeAuthorisationOptions> options)
        {
            Options = options.Value ?? ScopeAuthorisationOptions.Default;
        }

        public ScopeAuthorisationOptions Options { get; set; }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ScopeAuthorisationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == Options.ScopeClaimIdentifier && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            var scopes = context.User.FindFirst(c => c.Type == Options.ScopeClaimIdentifier && c.Issuer == requirement.Issuer).Value.Split(' ');

            if (scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}