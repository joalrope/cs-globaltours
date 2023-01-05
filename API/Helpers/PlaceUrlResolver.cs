using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class PlaceUrlResolver : IValueResolver<Place, PlaceDto, string>
    {
        private readonly IConfiguration _config;

        public PlaceUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Place source, PlaceDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;

            }

            return null!;
        }
    }
}