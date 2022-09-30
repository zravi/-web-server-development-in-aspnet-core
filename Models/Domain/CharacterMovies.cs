﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCharactersEFCodeFirst.Domain
{
    // [Table("CharacterMovies")]
    public class CharacterMovies
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}