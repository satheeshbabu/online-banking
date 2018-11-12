namespace WayneEnterprises.OnlineBanking.WebApi.Models
{
    public class ApplicationConfigurationModel
    {
        public string Bar { get; set; }
        public string Foo { get; set; }
        public Keycloak Keycloak { get; set; }
        public Info Info { get; set; }
    }

    public class Keycloak
    {
        public string Url { get; set; }
    }

    public class Info
    {
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
