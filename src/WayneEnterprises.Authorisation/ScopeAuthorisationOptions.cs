namespace WayneEnterprises.Authorisation
{
    public class ScopeAuthorisationOptions
    {
        public string ScopeClaimIdentifier { get; set; }

        public static ScopeAuthorisationOptions Default => new ScopeAuthorisationOptions
        {
            ScopeClaimIdentifier = "scope"
        };
    }
}