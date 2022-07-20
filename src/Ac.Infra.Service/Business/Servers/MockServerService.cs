using Ac.Infra.Service.Models.Servers;
using Ac.Infra.Service.ResourceParameters;

namespace Ac.Infra.Service.Business.Servers
{
    public class MockServerService : IServerService
    {
        private readonly ILogger<MockServerService> _logger;

        public MockServerService(ILogger<MockServerService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<ServerModel>> GetServers(ServerResourceParameters serverResourceParameters)
        {
            if (serverResourceParameters == null)
            {
                var msg = $"'{nameof(serverResourceParameters)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(serverResourceParameters));

                _logger.LogCritical(LoggingEvents.eidArgExGetServers, ex, msg);

                throw ex;
            }

            _logger.LogDebug(
                LoggingEvents.eidInfoServerServiceGet,
                "Getting Servers in Service : {serverResourceParameters}",
                serverResourceParameters);

            if (string.IsNullOrWhiteSpace(serverResourceParameters.Name)
                && string.IsNullOrWhiteSpace(serverResourceParameters.Domain)
                && string.IsNullOrWhiteSpace(serverResourceParameters.IpAddress)
                && string.IsNullOrWhiteSpace(serverResourceParameters.Description)
                && string.IsNullOrWhiteSpace(serverResourceParameters.FullyQualifiedDomainName)
                && !serverResourceParameters.IsVirtual.HasValue
                && string.IsNullOrWhiteSpace(serverResourceParameters.PhysicalHostName)
                && string.IsNullOrWhiteSpace(serverResourceParameters.Make)
                && string.IsNullOrWhiteSpace(serverResourceParameters.Model)
                && string.IsNullOrWhiteSpace(serverResourceParameters.SearchQuery))
            {
                return await Task.FromResult(GetAllServers());
            }

            var collection = GetAllServers() as IQueryable<ServerModel>;

            //Filter
            if (!string.IsNullOrWhiteSpace(serverResourceParameters.Name))
            {
                var name = serverResourceParameters.Name.Trim().ToLower();

                collection = collection!
                    .Where(s => s.Name.ToLower() == name);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.Domain))
            {
                var domain = serverResourceParameters.Domain.Trim().ToLower();

                collection = collection!
                    .Where(s => s.Domain.ToLower() == domain);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.IpAddress))
            {
                var ipAddress = serverResourceParameters.IpAddress.Trim().ToLower();

                collection = collection!
                    .Where(s => s.Domain.ToLower() == ipAddress);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.Description))
            {
                var description = serverResourceParameters.Description.Trim().ToLower();

                collection = collection!
                    .Where(s => s.Description.ToLower() == description);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.FullyQualifiedDomainName))
            {
                var fullyQualifiedDomainName = serverResourceParameters.FullyQualifiedDomainName.Trim().ToLower();

                collection = collection!
                    .Where(s => s.FullyQualifiedDomainName.ToLower() == fullyQualifiedDomainName);
            }

            if (serverResourceParameters.IsVirtual.HasValue)
            {
                collection = collection!
                    .Where(s => s.IsVirtual == serverResourceParameters.IsVirtual);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.PhysicalHostName))
            {
                var physicalHostName = serverResourceParameters.PhysicalHostName.Trim().ToLower();

                collection = collection!
                    .Where(s => s.PhysicalHostName.ToLower() == physicalHostName);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.Make))
            {
                var make = serverResourceParameters.Make.Trim().ToLower();

                collection = collection!
                    .Where(s => s.Make.ToLower() == make);
            }

            if (!string.IsNullOrWhiteSpace(serverResourceParameters.Model))
            {
                var model = serverResourceParameters.Model.Trim().ToLower();

                collection = collection!
                    .Where(s => s.Model.ToLower() == model);
            }

            //Search
            if (!string.IsNullOrWhiteSpace(serverResourceParameters.SearchQuery))
            {
                var searchQuery = serverResourceParameters.SearchQuery.Trim();

                collection = collection!
                    .Where(
                        s =>
                            s.Name.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.Domain.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.IpAddress.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.Description.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.FullyQualifiedDomainName.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.PhysicalHostName.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.Make.ToLower().Contains(searchQuery.ToLower())
                            ||
                            s.Model.ToLower().Contains(searchQuery.ToLower())
                        );
            }

            collection = collection!.OrderBy(s => s.Name);

            return await Task.FromResult(collection.ToList());
        }

        public async Task<ServerModel> GetServerById(Guid id)
        {
            _logger.LogDebug(
                LoggingEvents.eidInfoServerServiceGetById,
                "Getting Servers in Service by '{id}'", id);

            var res = await Task.FromResult(GetAllServers()
                .FirstOrDefault(s => s.Id == id));

            return res!;

            // we know res won't be null here due to the FirstOrDefault check above, so 
            // we can use the null-forgiving operator to notify the compiler of this
        }

        private static IEnumerable<ServerModel> GetAllServers()
        {
            return new List<ServerModel>
            {
                new ServerModel
                {
                    Id = Guid.Parse("{1B11111B-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "srv246",
                    Domain = "ml.local",
                    IpAddress = "172.17.146.246",
                    Description = "OpenShift PoC at HQ",
                    ManagementIp = "172.17.146.243",
                    FullyQualifiedDomainName = "srv246.ml.local",
                    IsVirtual = false,
                    Make = "HP",
                    Model = "ProLiant"
                },
                new ServerModel
                {
                    Id = Guid.Parse("{2B11111B-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "srv247",
                    Domain = "ml.local",
                    IpAddress = "172.17.146.247",
                    Description = "OpenShift PoC at HQ",
                    ManagementIp = "172.17.146.244",
                    FullyQualifiedDomainName = "srv247.ml.local",
                    IsVirtual = false,
                    Make = "HP",
                    Model = "ProLiant"
                },
                new ServerModel
                {
                    Id = Guid.Parse("{3B11111B-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "srv248",
                    Domain = "ml.local",
                    IpAddress = "172.17.146.248",
                    Description = "OpenShift PoC at HQ",
                    ManagementIp = "172.17.146.245",
                    FullyQualifiedDomainName = "srv248.ml.local",
                    IsVirtual = false,
                    Make = "HP",
                    Model = "ProLiant"
                },
                new ServerModel
                {
                    Id = Guid.Parse("{4B11111B-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "srv013",
                    Domain = "ml.local",
                    IpAddress = "172.17.146.249",
                    Description = "KVM Host for OpenShift PoC at HQ",
                    ManagementIp = "172.17.146.236",
                    FullyQualifiedDomainName = "srv013.ml.local",
                    IsVirtual = false,
                    Make = "IBM",
                    Model = "xSeries x3"
                },
                new ServerModel
                {
                    Id = Guid.Parse("{1C11111C-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "kafiotprdsh01",
                    Domain = "mms.local",
                    IpAddress = "172.17.164.170",
                    Description = "Kafka IoT Prod Broker",
                    FullyQualifiedDomainName = "kafiotprdsh01.mms.local",
                    IsVirtual = true,
                    PhysicalHostName = "tiger"
                },
                new ServerModel
                {
                    Id = Guid.Parse("{2C11111C-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "kafiotprdsh02",
                    Domain = "mms.local",
                    IpAddress = "172.17.164.171",
                    Description = "Kafka IoT Prod Broker",
                    FullyQualifiedDomainName = "kafiotprdsh02.mms.local",
                    IsVirtual = true,
                    PhysicalHostName = "ocean"
                },
                new ServerModel
                {
                    Id = Guid.Parse("{3C11111C-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "kafiotprdsh03",
                    Domain = "mms.local",
                    IpAddress = "172.17.164.176",
                    Description = "Kafka IoT Prod Broker",
                    FullyQualifiedDomainName = "kafiotprdsh03.mms.local",
                    IsVirtual = true,
                    PhysicalHostName = "charger"
                },
            }.AsQueryable();
        }
    }
}