using AutoMapper;
using MovieCharactersEFCodeFirst.Models.Domain;
using MovieCharactersEFCodeFirst.Models.DTO.Franchise;

namespace MovieCharactersEFCodeFirst.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDTO>()
                .ReverseMap();
            CreateMap<FranchiseCreateDTO, Franchise>()
                .ReverseMap();
            CreateMap<FranchiseEditDTO, Franchise>()
                .ReverseMap();
        }
    }
}