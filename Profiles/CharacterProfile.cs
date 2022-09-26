using AutoMapper;
using MovieCharactersEFCodeFirst.Models;
using MovieCharactersEFCodeFirst.Models.DTO.Character;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Character -> CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>();
            // Character -> CharacterCreateDTO
            CreateMap<CharacterCreateDTO, Character>();
            // Character -> CharacterEditDTO
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}