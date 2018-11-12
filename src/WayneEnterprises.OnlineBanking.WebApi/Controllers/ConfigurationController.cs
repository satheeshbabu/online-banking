using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Steeltoe.Extensions.Configuration.ConfigServer;
using WayneEnterprises.OnlineBanking.WebApi.Models;

namespace WayneEnterprises.OnlineBanking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private IOptionsSnapshot<ConfigurationModel> Configuration { get; }

        private ConfigServerClientSettingsOptions ConfigServerClientSettingsOptions { get; }

        private IConfigurationRoot Config { get; }

        public ConfigurationController(
            IConfigurationRoot config,
            IOptionsSnapshot<ConfigurationModel> configuration,
            IOptions<ConfigServerClientSettingsOptions> configServerSettings)
        {
            if (configuration != null)
            {
                Configuration = configuration;
            }

            if (configServerSettings != null)
            {
                ConfigServerClientSettingsOptions = configServerSettings.Value;
            }

            Config = config;
        }

        [HttpGet("[action]")]
        public ActionResult<ConfigurationModel> Settings()
        {
            return Ok();
        }
    }
}
