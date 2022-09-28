using AutoMapper;
using MovieCharactersEFCodeFirst.Domain;
using MovieCharactersEFCodeFirst.DTO.Franchise;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(fdto => fdto.Movies, opt => opt
                    .MapFrom(f => f.Movies.Select(m => m.Id).ToList()))
                .ReverseMap();
            CreateMap<FranchiseCreateDTO, Franchise>()
                .ReverseMap();
            CreateMap<FranchiseEditDTO, Franchise>()
                .ReverseMap();
        }
    }
}