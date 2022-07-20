namespace Ac.Infra.Service.ResourceParameters
{
    public class ServerResourceParameters : BaseResourceParameters
    {
        public string? Name { get; set; }

        public string? Domain { get; set; }

        public string? IpAddress { get; set; }

        public string? Description { get; set; }

        public string? FullyQualifiedDomainName { get; set; }


        public bool? IsVirtual { get; set; } = null;

        public string? PhysicalHostName { get; set; }


        public string? Make { get; set; }

        public string? Model { get; set; }
    }
}