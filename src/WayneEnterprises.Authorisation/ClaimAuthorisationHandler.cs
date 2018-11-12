using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace WayneEnterprises.Authorisation
{
    public class ClaimAuthorisationHandler : AuthorizationHandler<ClaimAuthorisationRequirement>
    {
        public ClaimAuthorisationHandler(IOptions<ClaimAuthorisationOptions> options)
        {
            Options = options.Value ?? ClaimAuthorisationOptions.Default;
        }

        public ClaimAuthorisationOptions Options { get; set; }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ClaimAuthorisationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == requirement.Claim.Key && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            var claim = context.User.Claims.FirstOrDefault(x => x.Type == Options.RoleClaimIdentifier);
            var role = claim?.Value;

            if (context.User.HasClaim(c => 
                    c.Type == requirement.Claim.Key && 
                    c.Value == requirement.Claim.Value) || 
                    context.User.IsInRole(role))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}