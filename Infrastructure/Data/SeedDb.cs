using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SeedDb
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Country!.Any())
                {
                    var countryData = File.ReadAllText("../Infrastructure/Data/SeedData/countries.json");
                    var countries = JsonSerializer.Deserialize<List<Country>>(countryData);

                    foreach (var country in countries!)
                    {
                        await context.Country!.AddAsync(country);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Category!.Any())
                {
                    var categoryData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    foreach (var category in categories!)
                    {
                        await context.Category!.AddAsync(category);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Place!.Any())
                {
                    var placesData = File.ReadAllText("../Infrastructure/Data/SeedData/places.json");
                    var places = JsonSerializer.Deserialize<List<Place>>(placesData);

                    foreach (var place in places!)
                    {
                        await context.Place!.AddAsync(place);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedDb>();
                logger.LogError(ex.Message);
            }

        }
    }
}