namespace Ac.Infra.Service.DataAccess.Entities.Servers
{
    public class VirtualServer : Server
    {
        /// <summary>
        /// The name of the Physical Host for this Virtual Guest
        /// </summary>
        //[Required]
        public string PhysicalHostName { get; set; }

        public VirtualServer(
            string name,
            string domain,
            string ipAddress,
            string description,
            string physicalHostName)
                : base(name, domain, ipAddress, description)
        {
            PhysicalHostName = physicalHostName;
        }
    }
}