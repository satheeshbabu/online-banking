namespace WayneEnterprises.Authorisation
{
    public class ClaimAuthorisationOptions
    {
        public string RoleClaimIdentifier { get; set; }

        public static ClaimAuthorisationOptions Default => new ClaimAuthorisationOptions
        {
            RoleClaimIdentifier = "Administrator"
        };
    }
}