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
        private IOptionsSnapshot<ApplicationConfigurationModel> ApplicationConfiguration { get; }

        private ConfigServerClientSettingsOptions ServerConfiguration { get; }

        private IConfigurationRoot Config { get; }

        public ConfigurationController(
            IConfigurationRoot config,
            IOptionsSnapshot<ApplicationConfigurationModel> configuration,
            IOptions<ConfigServerClientSettingsOptions> configServerSettings)
        {
            if (configuration != null)
            {
                ApplicationConfiguration = configuration;
            }

            if (configServerSettings != null)
            {
                ServerConfiguration = configServerSettings.Value;
            }

            Config = config;
        }

        [HttpGet("[action]")]
        public ActionResult<ApplicationConfigurationModel> Application()
        {
            return Ok(ApplicationConfiguration.Value);
        }

        [HttpGet("[action]")]
        public ActionResult<ConfigServerClientSettingsOptions> Server()
        {
            return Ok(ServerConfiguration);
        }
    }
}
