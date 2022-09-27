using AutoMapper;
using MovieCharactersEFCodeFirst.DTO.Character;
using MovieCharactersEFCodeFirst.Models.Domain;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Character -> CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>()
                // Turn related movies to int list
                // .ForMember(cdto => cdto.Movies, opt => opt
                //     .MapFrom(c => c.Movies.Select(c => c.Id).ToList()))
                .ReverseMap();
            // Character -> CharacterCreateDTO
            CreateMap<CharacterCreateDTO, Character>();
            // Character -> CharacterEditDTO
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}