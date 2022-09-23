using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieCharactersEFCodeFirst.Models
{
    [Table("Character")]
    public class MovieCharacter
    {
        public int Id { get; set; }
        [MaxLength(60)]
        public string FullName { get; set; }
        [MaxLength(03)]
        public int? Age { get; set; }
        [MaxLength(40)]
        public string? Alias { get; set; }
        [MaxLength(15)]
        public string? Gender { get; set; }
        [MaxLength(100)]
        public string? Picture { get; set; }
    }
}