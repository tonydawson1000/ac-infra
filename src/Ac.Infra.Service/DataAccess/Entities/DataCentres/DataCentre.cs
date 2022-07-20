namespace Ac.Infra.Service.DataAccess.Entities.DataCentres
{
    public class DataCentre
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string Location { get; set; }

        public DataCentre(
            string name,
            string location)
        {
            Name = name;
            Location = location;
        }
    }
}