using Ac.Infra.Service.Models.DataCentres;
using Ac.Infra.Service.ResourceParameters;

namespace Ac.Infra.Service.Business.DataCentres
{
    public class DataCentreService : IDataCentreService
    {
        private readonly ILogger<DataCentreService> _logger;

        public DataCentreService(ILogger<DataCentreService> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<DataCentreModel>> GetDataCentres(DataCentreResourceParameters dataCentreResourceParameters)
        {
            throw new NotImplementedException();
        }

        public Task<DataCentreModel> GetDataCentreById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}