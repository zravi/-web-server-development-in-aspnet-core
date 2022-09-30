using AutoMapper;
using MovieCharactersEFCodeFirst.Domain;
using MovieCharactersEFCodeFirst.DTO.Character;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Character -> CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>()
                .ReverseMap();
            // Character -> CharacterCreateDTO
            CreateMap<CharacterCreateDTO, Character>();
            // Character -> CharacterEditDTO
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}