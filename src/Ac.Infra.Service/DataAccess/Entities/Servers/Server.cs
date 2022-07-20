namespace Ac.Infra.Service.DataAccess.Entities.Servers
{
    /// <summary>
    /// Base class for all servers
    /// </summary>
    public abstract class Server
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //[Required]
        //[MaxLength(14)]
        public string Name { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Domain { get; set; }

        //[Required]
        //[MaxLength(16)]
        public string IpAddress { get; set; }

        //[Required]
        //[MaxLength(250)]
        public string Description { get; set; }

        //[NotMapped]
        public string FullyQualifiedDomainName
        {
            get { return $"{Name}.{Domain}"; }
        }

        public Server(
            string name,
            string domain,
            string ipAddress,
            string description)
        {
            Name = name;
            Domain = domain;
            IpAddress = ipAddress;
            Description = description;
        }
    }
}