using Ac.Infra.Service.Models.DataCentres;
using Ac.Infra.Service.ResourceParameters;

namespace Ac.Infra.Service.Business.DataCentres
{
    public interface IDataCentreService
    {
        Task<IEnumerable<DataCentreModel>> GetDataCentres(DataCentreResourceParameters dataCentreResourceParameters);

        Task<DataCentreModel> GetDataCentreById(Guid id);
    }
}