namespace Ac.Infra.Service.Models.Servers
{
    public class ServerModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Domain { get; set; } = string.Empty;

        public string IpAddress { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string FullyQualifiedDomainName { get; set; } = string.Empty;

        public bool IsVirtual { get; set; } = false;

        public string PhysicalHostName { get; set; } = string.Empty;

        public string ManagementIp { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}