using Ac.Infra.Service.Models.Servers;
using Ac.Infra.Service.ResourceParameters;

namespace Ac.Infra.Service.Business.Servers
{
    public interface IServerService
    {
        Task<IEnumerable<ServerModel>> GetServers(ServerResourceParameters serverResourceParameters);

        Task<ServerModel> GetServerById(Guid id);
    }
}