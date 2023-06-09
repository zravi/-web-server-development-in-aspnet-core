﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersEFCodeFirst.Domain
{
    [Table("Movie")]
    public class Movie
    {
        // public Movie()
        // {
        //     this.Characters = new HashSet<Character>();
        // }
        // Primary Key
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
        [MaxLength(60)]
        public string? Director { get; set; }
        [MaxLength(300)]
        public string? Picture { get; set; }
        [MaxLength(300)]
        public string? Trailer { get; set; }
        
        // Relationships
        public ICollection<Character>? Characters { get; set; }
        public int? FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
    }
}