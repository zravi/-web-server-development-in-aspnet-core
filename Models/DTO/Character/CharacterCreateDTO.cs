namespace MovieCharactersEFCodeFirst.Models.DTO.Character
{
    public class CharacterCreateDTO
    {
        public string FullName { get; set; }
        public string Alias { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
    }
}