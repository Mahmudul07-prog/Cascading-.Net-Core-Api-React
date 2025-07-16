namespace Cascading_React.Server.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }=default!;

        public ICollection<Division> Divisions { get; set; } = new List<Division>();
    }

}
