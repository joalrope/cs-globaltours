using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

#nullable disable
namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Place, PlaceDto>()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country!.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category!.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<PlaceUrlResolver>());
        }
    }
}
#nullable enable