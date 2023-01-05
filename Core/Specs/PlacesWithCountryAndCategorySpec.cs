using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specs
{
    public class PlacesWithCountryAndCategorySpec : BaseSpecification<Place>
    {
        public PlacesWithCountryAndCategorySpec()
        {
            AddInclude(x => x.Country!);
            AddInclude(x => x.Category!);
        }

        public PlacesWithCountryAndCategorySpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Country!);
            AddInclude(x => x.Category!);
        }

    }
}