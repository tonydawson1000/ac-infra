using Ac.Infra.Service.Business.Servers;
using Ac.Infra.Service.DataAccess.Entities.Servers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ac.Infra.Service.Test.Business
{
    [Collection("No parallelism")]
    public class ServerFactoryTests : IDisposable
    {
        private ServerFactory _serverFactory;

        private const string TestServerName = "dummyserver01";
        private const string TestServerDomain = "mms.local";
        private const string TestServerIpAddress = "1.1.1.1";
        private const string TestServerDescription = "Dummy Server for Test";

        private const string TestVirtualServerPhysicalHostName = "physicalhost01";

        private const string TestPhysicalServerManagementIp = "2.2.2.2";
        private const string TestPhysicalServerMake = "Dell";
        private const string TestPhysicalServerModel = "XPS17";

        private const string TestFqdn = "dummyserver01.mms.local";

        public ServerFactoryTests()
        {
            var loggerMock = new Mock<ILogger<ServerFactory>>();

            _serverFactory = new ServerFactory(loggerMock.Object);
        }

        [Fact]
        public void Should_HaveManafementIp_WhenPhysicalServerCreated()
        {
            // Arrange

            // Act
            var server = (PhysicalServer)CreateTestPhysicalServer();

            //Assert
            Assert.Equal(TestPhysicalServerManagementIp, server.ManagementIp);
        }

        [Fact]
        public void Should_HaveMake_WhenPhysicalServerCreated()
        {
            // Arrange

            // Act
            var server = (PhysicalServer)CreateTestPhysicalServer();

            //Assert
            Assert.Equal(TestPhysicalServerMake, server.Make);
        }

        [Fact]
        public void Should_HaveModel_WhenPhysicalServerCreated()
        {
            // Arrange

            // Act
            var server = (PhysicalServer)CreateTestPhysicalServer();

            //Assert
            Assert.Equal(TestPhysicalServerModel, server.Model);
        }

        [Fact]
        public void Should_HavePhysicalHost_WhenVirtualServerCreated()
        {
            // Arrange

            // Act
            var server = (VirtualServer)CreateTestVirtualServer();

            //Assert
            Assert.Equal(TestVirtualServerPhysicalHostName, server.PhysicalHostName);
        }

        [Fact]
        public void Should_HaveCorrectFqdn_WhenVirtualServerCreated()
        {
            // Arrange

            // Act
            var server = CreateTestVirtualServer();

            //Assert
            Assert.Equal(TestFqdn, server.FullyQualifiedDomainName);
        }

        [Fact]
        public void Should_HaveCorrectFqdn_WhenPhysicalServerCreated()
        {
            // Arrange

            // Act
            var server = CreateTestPhysicalServer();

            //Assert
            Assert.Equal(TestFqdn, server.FullyQualifiedDomainName);
        }

        [Fact]
        public void Should_CreateAVirtualServerInstance_WhenVirtualHostCreated()
        {
            // Arrange

            // Act
            var server = CreateTestVirtualServer();

            //Assert
            Assert.IsType<VirtualServer>(server);
        }

        [Fact]
        public void Should_CreateAPhysicalServerInstance_WhenPhysicalHostCreated()
        {
            // Arrange

            // Act
            var server = CreateTestPhysicalServer();

            //Assert
            Assert.IsType<PhysicalServer>(server);
        }

        private Server CreateTestVirtualServer()
        {
            return _serverFactory.CreateServer
                (TestServerName,
                TestServerDomain,
                TestServerIpAddress,
                TestServerDescription,
                TestVirtualServerPhysicalHostName,
                isVirtual: true,
                managementIp: null,
                make: null,
                model: null);
        }

        private Server CreateTestPhysicalServer()
        {
            return _serverFactory.CreateServer
                (TestServerName,
                TestServerDomain,
                TestServerIpAddress,
                TestServerDescription,
                physicalHostName: null,
                isVirtual: false,
                TestPhysicalServerManagementIp,
                TestPhysicalServerMake,
                TestPhysicalServerModel);
        }

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}