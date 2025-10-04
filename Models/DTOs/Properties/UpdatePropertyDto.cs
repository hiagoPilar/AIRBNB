﻿using AIRBNB.Enum;

namespace AIRBNB.Models.DTOs.Properties
{
    public class UpdatePropertyDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public decimal? PricePerNight { get; set; }
        public PropertyType? PropertyType { get; set; }

    }
}
