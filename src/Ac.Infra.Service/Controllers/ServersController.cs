using Ac.Infra.Service.Business.Servers;
using Ac.Infra.Service.Models.Servers;
using Ac.Infra.Service.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace Ac.Infra.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServersController : ControllerBase
    {
        private readonly ILogger<ServersController> _logger;
        private readonly IServerService _serverService;

        public ServersController(
            ILogger<ServersController> logger,
            IServerService serverService)
        {
            _logger = logger;
            _serverService = serverService;
        }

        [HttpGet(Name = "GetServers")]
        [ProducesResponseType(typeof(IEnumerable<ServerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServerModel>>> GetServers(
            [FromQuery] ServerResourceParameters serverResourceParameters)
        {
            _logger.LogDebug(
                LoggingEvents.eidInfoServerControllerGet,
                "Getting Servers in API : '{serverResourceParameters}'",
                serverResourceParameters);

            var servers = await _serverService.GetServers(serverResourceParameters);

            if (servers == null || !servers.Any())
            {
                _logger.LogWarning(
                    LoggingEvents.eidWarningServerControllerGetNotFound,
                    "No Servers Found '{serverResourceParameters}'",
                    serverResourceParameters);

                return NotFound();
            }

            return Ok(servers);
        }

        [HttpGet("{id}", Name = "GetServerById")]
        [ProducesResponseType(typeof(ServerModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServerModel>> GetServerById(Guid id)
        {
            _logger.LogDebug(
                LoggingEvents.eidInfoServerControllerGetById,
                "Getting Server in API by '{id}'", id);

            var server = await _serverService.GetServerById(id);

            if (server == null)
            {
                _logger.LogWarning(
                    LoggingEvents.eidWarningServerControllerGetByIdNotFound,
                    "No Server Found with id = '{id}'", id);

                return NotFound();
            }

            return Ok(server);
        }
    }
}