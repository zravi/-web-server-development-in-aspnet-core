﻿using AutoMapper;
using MovieCharactersEFCodeFirst.DTO.Franchise;
using MovieCharactersEFCodeFirst.Models.Domain;

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