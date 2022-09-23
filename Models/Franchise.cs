using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersEFCodeFirst.Models
{
    [Table("Franchise")]
    public class Franchise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}