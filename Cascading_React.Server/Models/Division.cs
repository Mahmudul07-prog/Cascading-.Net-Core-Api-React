using System.ComponentModel.DataAnnotations.Schema;

namespace Cascading_React.Server.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; } = default!;

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
