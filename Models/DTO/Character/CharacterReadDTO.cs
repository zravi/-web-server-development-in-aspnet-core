namespace MovieCharactersEFCodeFirst.Models.DTO.Character
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public List<int> Movies { get; set; }
    }
}