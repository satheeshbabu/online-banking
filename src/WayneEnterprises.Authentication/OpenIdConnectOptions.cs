using System.Collections.Generic;

namespace WayneEnterprises.Authentication
{
    public class OpenIdConnectOptions
    {
        public string Authority { get; set; }
        public string Audience { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public bool RequireHttpsMetadata { get; set; } = false;
        public IList<string> Scopes { get; set; }
        public string SignedOutRedirectUri { get; set; }
    }
}