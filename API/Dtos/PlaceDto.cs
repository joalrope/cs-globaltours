using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PlaceDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double ApproximateCost { get; set; }

        public string? ImageUrl { get; set; }

        public string? Country { get; set; }

        public string? Category { get; set; }
    }
}