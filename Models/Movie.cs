using System.ComponentModel.DataAnnotations;

namespace MovieCharactersEFCodeFirst.Models
{
    public class Movie
    {
        // Primary Key
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
    }
}