using Ac.Infra.Service.Business.DataCentres;
using Ac.Infra.Service.DataAccess.Entities.DataCentres;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ac.Infra.Service.Test.Business
{
    [Collection("No parallelism")]
    public class DataCentreFactoryTests : IDisposable
    {
        private DataCentreFactory _dataCentreFactory;
        
        private const string TestDataCentreName = "Dummy DC";
        private const string TestDataCentreLocation = "UK";

        public DataCentreFactoryTests()
        {
            var loggerMock = new Mock<ILogger<DataCentreFactory>>();

            _dataCentreFactory = new DataCentreFactory(loggerMock.Object);
        }

        [Fact]
        public void Should_HaveValidLocation_WhenCreated()
        {
            // Arrange

            // Act
            var dataCentre = CreateTestDataCentre();

            //Assert
            Assert.Equal(TestDataCentreLocation, dataCentre.Location);
        }

        [Fact]
        public void Should_HaveValidName_WhenCreated()
        {
            // Arrange

            // Act
            var dataCentre = CreateTestDataCentre();

            //Assert
            Assert.Equal(TestDataCentreName, dataCentre.Name);
        }

        [Fact]
        public void Should_CreateADataCentreInstance_WhenCreated()
        {
            // Arrange

            // Act
            var dataCentre = CreateTestDataCentre();

            //Assert
            Assert.IsType<DataCentre>(dataCentre);
        }

        private DataCentre CreateTestDataCentre()
        {
            return _dataCentreFactory.CreateDataCentre
                (TestDataCentreName,
                TestDataCentreLocation);
        }

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}