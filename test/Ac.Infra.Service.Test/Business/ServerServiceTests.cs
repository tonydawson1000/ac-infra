using Ac.Infra.Service.Business.Servers;
using Ac.Infra.Service.Models.Servers;
using Ac.Infra.Service.ResourceParameters;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ac.Infra.Service.Test.Business
{
    [Collection("No parallelism")]
    public class ServerServiceTests : IDisposable
    {
        private ServerService _serverService;

        private Guid TestServerId = Guid.Parse("{1B11111B-4002-401B-BCFF-114EB2CAB39F}");

        public ServerServiceTests()
        {
            var loggerMock = new Mock<ILogger<ServerService>>();

            _serverService = new ServerService(loggerMock.Object);
        }

        [Fact]
        public void Should_ReturnAListOfServerModels_WhenGetAll()
        {
            // Arrange
            var srp = new ServerResourceParameters();

            // Act
            var servers = _serverService.GetServers(srp);

            //Assert
            Assert.IsType<List<ServerModel>>(servers);
        }

        [Fact]
        public void Should_ReturnASingleServerModel_WhenGetById()
        {
            // Arrange

            // Act
            var server = _serverService.GetServerById(TestServerId);

            //Assert
            Assert.IsType<ServerModel>(server);
        }

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}