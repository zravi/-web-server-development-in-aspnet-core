using AutoMapper;
using MovieCharactersEFCodeFirst.DTO.Movie;
using MovieCharactersEFCodeFirst.Models.Domain;
using MovieCharactersEFCodeFirst.Models.DTO.Movie;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(mdto => mdto.Characters, opt => opt
                    .MapFrom(m => m.Characters.Select(c=> c.Id).ToList()))
                .ReverseMap();
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieEditDTO, Movie>();
        }
    }
}