﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieCharactersEFCodeFirst.Models
{
    [Table("Character")]
    public class Character
    {
        public Character()
        {
            this.Movie = new HashSet<Movie>();
        }
        public int Id { get; set; }
        [MaxLength(60)]
        public string FullName { get; set; }
        public int? Age { get; set; }
        [MaxLength(60)]
        public string? Alias { get; set; }
        [MaxLength(15)]
        public string? Gender { get; set; }
        [MaxLength(300)]
        public string? Picture { get; set; }
        
        // Relationships
        public ICollection<Movie> Movie { get; set; }
    }
}