using System.ComponentModel.DataAnnotations.Schema;

namespace Cascading_React.Server.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        [ForeignKey("Division")]
        public int DivisionId { get; set; }

        public Division Division { get; set; } = default!;
    }
}
