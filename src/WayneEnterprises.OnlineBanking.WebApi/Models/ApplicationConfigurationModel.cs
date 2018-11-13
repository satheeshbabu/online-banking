namespace WayneEnterprises.OnlineBanking.WebApi.Models
{
    public class ApplicationConfigurationModel
    {
        public string Audience { get; set; }
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string MaxAttempts { get; set; }
        public string Timeout { get; set; }
    }
}
