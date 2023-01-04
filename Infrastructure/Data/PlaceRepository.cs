using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly AppDbContext? _db;

        public PlaceRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Place> GetPlaceAsync(int id)
        {
            Place? place = await _db!.Place!.FindAsync(id);

            return place!;
        }

        public async Task<IReadOnlyList<Place>> GetPlacesAsync()
        {
            return await _db!.Place!.ToListAsync();
        }
    }
}