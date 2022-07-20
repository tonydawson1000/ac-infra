using Ac.Infra.Service.Models.DataCentres;
using Ac.Infra.Service.ResourceParameters;

namespace Ac.Infra.Service.Business.DataCentres
{
    public class MockDataCentreService : IDataCentreService
    {
        private readonly ILogger<MockDataCentreService> _logger;

        public MockDataCentreService(ILogger<MockDataCentreService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<DataCentreModel>> GetDataCentres(DataCentreResourceParameters dataCentreResourceParameters)
        {
            if (dataCentreResourceParameters == null)
            {
                var msg = $"'{nameof(dataCentreResourceParameters)}' cannot be null or empty.";
                var ex = new ArgumentException(msg, nameof(dataCentreResourceParameters));

                _logger.LogCritical(LoggingEvents.eidArgExGetDataCentres, ex, msg);

                throw ex;
            }

            _logger.LogDebug(
                LoggingEvents.eidInfoDataCentreServiceGet,
                "Getting DataCentres in Service : {dataCentreResourceParameters}",
                dataCentreResourceParameters);

            if (string.IsNullOrWhiteSpace(dataCentreResourceParameters.Name)
                && string.IsNullOrWhiteSpace(dataCentreResourceParameters.Location)
                && string.IsNullOrWhiteSpace(dataCentreResourceParameters.SearchQuery))
            {
                return await Task.FromResult(GetAllDataCentres());
            }

            var collection = GetAllDataCentres() as IQueryable<DataCentreModel>;

            // we know collection won't be null here due to the IQueryable check above, so 
            // we can use the null-forgiving operator to notify the compiler of this

            //Filter
            if (!string.IsNullOrWhiteSpace(dataCentreResourceParameters.Name))
            {
                var name = dataCentreResourceParameters.Name.Trim().ToLower();

                collection = collection!
                    .Where(dc => dc.Name.ToLower() == name);
            }

            if (!string.IsNullOrWhiteSpace(dataCentreResourceParameters.Location))
            {
                var location = dataCentreResourceParameters.Location.Trim().ToLower();

                collection = collection!
                    .Where(dc => dc.Location.ToLower() == location);
            }

            //Search
            if (!string.IsNullOrWhiteSpace(dataCentreResourceParameters.SearchQuery))
            {
                var searchQuery = dataCentreResourceParameters.SearchQuery.Trim();

                collection = collection!
                    .Where(
                        dc => 
                        dc.Name.ToLower().Contains(searchQuery.ToLower())
                        ||
                        dc.Location.ToLower().Contains(searchQuery.ToLower())
                        );
            }

            collection = collection!.OrderBy(dc => dc.Name);

            return await Task.FromResult(collection.ToList());
        }

        public async Task<DataCentreModel> GetDataCentreById(Guid id)
        {
            _logger.LogDebug(
                LoggingEvents.eidInfoDataCentreServiceGetById,
                "Getting DataCentres in Service by '{id}'", id);

            var res = await Task.FromResult(GetAllDataCentres()
                .FirstOrDefault(dc => dc.Id == id));

            return res!;
            
            // we know res won't be null here due to the FirstOrDefault check above, so 
            // we can use the null-forgiving operator to notify the compiler of this
        }

        private static IEnumerable<DataCentreModel> GetAllDataCentres()
        {
            return new List<DataCentreModel>
            {
                new DataCentreModel
                {
                    Id = Guid.Parse("{1A11111A-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "HQ",
                    Location = "Nottingham"
                },
                new DataCentreModel
                {
                    Id = Guid.Parse("{2A11111A-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "PG",
                    Location = "London"
                },
                new DataCentreModel
                {
                    Id = Guid.Parse("{3A11111A-4002-401B-BCFF-114EB2CAB39F}"),
                    Name = "SH",
                    Location = "London"
                }
            }.AsQueryable();
        }
    }
}