using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace MovieCharactersEFCodeFirst.Models
{
    [Table("Movie")]
    public class Movie
    {
        // Primary Key
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string? Genre { get; set; }
        [Required]
        [MaxLength(4)]
        public int? ReleaseYear { get; set; }
        [MaxLength(30)]
        public string? Director { get; set; }
        [MaxLength(100)]
        public string? Picture { get; set; }
        [MaxLength(100)]
        public string? Trailer { get; set; }
        public int FranchiseId { get; set; }
        // Reference navigation property
        public Franchise Franchise { get; set; }
    }
}