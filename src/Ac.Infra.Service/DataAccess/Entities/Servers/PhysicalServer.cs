namespace Ac.Infra.Service.DataAccess.Entities.Servers
{
    public class PhysicalServer : Server
    {
        public string ManagementIp { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }

        public PhysicalServer(
            string name,
            string domain,
            string ipAddress,
            string description,
            string managementIp,
            string make,
            string model)
                : base(name, domain, ipAddress, description)
        {
            ManagementIp = managementIp;

            Make = make;
            Model = model;
        }
    }
}