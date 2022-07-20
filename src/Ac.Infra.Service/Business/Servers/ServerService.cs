using Ac.Infra.Service.Models.Servers;
using Ac.Infra.Service.ResourceParameters;

namespace Ac.Infra.Service.Business.Servers
{
    public class ServerService : IServerService
    {
        private readonly ILogger<ServerService> _logger;

        public ServerService(ILogger<ServerService> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<ServerModel>> GetServers(ServerResourceParameters serverResourceParameters)
        {
            throw new NotImplementedException();
        }

        public Task<ServerModel> GetServerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}