namespace MovieCharactersEFCodeFirst.DTO.Character
{
    public class CharacterEditDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
    }
}