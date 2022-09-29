using AutoMapper;
using MovieCharactersEFCodeFirst.Domain;
using MovieCharactersEFCodeFirst.DTO.Movie;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(mdto => mdto.Characters, opt => opt
                    .MapFrom(m => m.Characters.Select(c=>  c.FullName).ToList()))
                .ReverseMap();
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieEditDTO, Movie>();
        }
    }
}