using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersEFCodeFirst.Models
{
    [Table("Franchise")]
    public class Franchise
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        
        // Relationships
        public ICollection<Movie> Movies { get; set; }
    }
}