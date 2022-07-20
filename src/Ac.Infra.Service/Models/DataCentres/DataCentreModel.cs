namespace Ac.Infra.Service.Models.DataCentres
{
    public class DataCentreModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}