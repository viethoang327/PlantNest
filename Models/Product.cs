﻿namespace PlantNestApp.Models
{
    public class Product : Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image {get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

    }
}
