using Ac.Infra.Service.DataAccess.Entities.Servers;

namespace Ac.Infra.Service.Business.Servers
{
    public class ServerFactory
    {
        private readonly ILogger<ServerFactory> _logger;

        public ServerFactory(ILogger<ServerFactory> logger)
        {
            _logger = logger;
        }

        public virtual Server CreateServer(
            string name,
            string domain,
            string ipAddress,
            string description,
            string? physicalHostName = null,
            bool isVirtual = false,
            string? managementIp = null,
            string? make = null,
            string? model = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                var msg = $"'{nameof(name)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(name));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerName, ex, msg);

                throw ex;
            }

            if (string.IsNullOrEmpty(domain))
            {
                var msg = $"'{nameof(domain)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(domain));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerDomain, ex, msg);

                throw ex;
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                var msg = $"'{nameof(ipAddress)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(ipAddress));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerIpAddress, ex, msg);

                throw ex;
            }

            if (string.IsNullOrEmpty(description))
            {
                var msg = $"'{nameof(description)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(description));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerDescription, ex, msg);

                throw ex;
            }

            if(physicalHostName == null && isVirtual)
            {
                var msg = $"'{nameof(physicalHostName)}' cannot be null or empty when the server is virtual.";
                var ex = new ArgumentException(msg, nameof(physicalHostName));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerVirtualServerPhysicalHostName, ex, msg);

                throw ex;
            }

            if(isVirtual)
            {
                return new VirtualServer(
                    name,
                    domain,
                    ipAddress,
                    description,
                    physicalHostName!);

                // we know physicalHostName won't be null here due to the check above, so 
                // we can use the null-forgiving operator to notify the compiler of this
            }

            if (!isVirtual && managementIp == null)
            {
                var msg = $"'{nameof(managementIp)}' cannot be null or empty when the server is physical.";
                var ex = new ArgumentException(msg, nameof(managementIp));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerPhysicalManagementIp, ex, msg);

                throw ex;
            }

            if (!isVirtual && make == null)
            {
                var msg = $"'{nameof(make)}' cannot be null or empty when the server is physical.";
                var ex = new ArgumentException(msg, nameof(make));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerPhysicalMake, ex, msg);

                throw ex;
            }

            if (!isVirtual && model == null)
            {
                var msg = $"'{nameof(model)}' cannot be null or empty when the server is physical.";
                var ex = new ArgumentException(msg, nameof(model));

                _logger.LogCritical(LoggingEvents.eidArgExCreateServerPhysicalModel, ex, msg);

                throw ex;
            }

            return new PhysicalServer(
                name,
                domain,
                ipAddress,
                description,
                managementIp!,
                make!,
                model!);

            // we know managementIp, make and model won't be null here due to the check above, so 
            // we can use the null-forgiving operator to notify the compiler of this
        }
    }
}