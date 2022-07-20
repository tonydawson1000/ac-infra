using Ac.Infra.Service.DataAccess.Entities.DataCentres;

namespace Ac.Infra.Service.Business.DataCentres
{
    public class DataCentreFactory
    {
        private readonly ILogger<DataCentreFactory> _logger;

        public DataCentreFactory(
            ILogger<DataCentreFactory> logger)
        {
            _logger = logger;
        }

        public virtual DataCentre CreateDataCentre(
            string name,
            string location)
        {
            if (string.IsNullOrEmpty(name))
            {
                var msg = $"'{nameof(name)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(name));

                _logger.LogCritical(LoggingEvents.eidArgExCreateDataCentreName, ex, msg);

                throw ex;
            }

            if (string.IsNullOrEmpty(location))
            {
                var msg = $"'{nameof(location)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(location));

                _logger.LogCritical(LoggingEvents.eidArgExCreateDataCentreLocation, ex, msg);

                throw ex;
            }

            return new DataCentre(
                name,
                location);
        }
    }
}