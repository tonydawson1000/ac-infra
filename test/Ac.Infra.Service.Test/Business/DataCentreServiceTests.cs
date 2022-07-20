using Ac.Infra.Service.Business.DataCentres;
using Ac.Infra.Service.Models.DataCentres;
using Ac.Infra.Service.ResourceParameters;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ac.Infra.Service.Test.Business
{
    [Collection("No parallelism")]
    public class DataCentreServiceTests : IDisposable
    {
        private DataCentreService _dataCentreService;

        private Guid TestDataCentreId = Guid.Parse("{1A11111A-4002-401B-BCFF-114EB2CAB39F}");

        public DataCentreServiceTests()
        {
            var loggerMock = new Mock<ILogger<DataCentreService>>();

            _dataCentreService = new DataCentreService(loggerMock.Object);
        }

        [Fact]
        public void Should_ReturnAListOfDataCentreModels_WhenGetAll()
        {
            // Arrange
            var dcrp = new DataCentreResourceParameters();

            // Act
            var dataCentres = _dataCentreService.GetDataCentres(dcrp);

            //Assert
            Assert.IsType<List<DataCentreModel>>(dataCentres);
        }

        [Fact]
        public void Should_ReturnASingleDataCentreModel_WhenGetById()
        {
            // Arrange

            // Act
            var dataCentre = _dataCentreService.GetDataCentreById(TestDataCentreId);

            //Assert
            Assert.IsType<DataCentreModel>(dataCentre);
        }

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}