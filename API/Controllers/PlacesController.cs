using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Country> _countryRepo;
        private readonly IRepository<Place> _placeRepo;
        private readonly IMapper _mapper;

        public PlacesController(IRepository<Place> placeRepo, IRepository<Country> countryRepo, IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _countryRepo = countryRepo;
            _placeRepo = placeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PlaceDto>>> GetPlaces()
        {
            var spec = new PlacesWithCountryAndCategorySpec();
            var places = await _placeRepo.GetAllSpec(spec);
            var mapper = _mapper.Map<IReadOnlyList<Place>, IReadOnlyList<PlaceDto>>(places);

            return Ok(mapper);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceDto>> GetPlace(int id)
        {
            var spec = new PlacesWithCountryAndCategorySpec(id);
            var place = await _placeRepo!.GetOneSpec(spec);
            return _mapper.Map<Place, PlaceDto>(place);
        }

        [HttpGet("countries")]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            var countries = await _countryRepo.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("countries/{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            return await _countryRepo!.GetOneAsync(id);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }
        [HttpGet("categories/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryRepo!.GetOneAsync(id);
        }
    }



}
