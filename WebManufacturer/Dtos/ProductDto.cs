using System;
using System.ComponentModel.DataAnnotations;

namespace WebManufacturer
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double Weight { get; set; }
        public string Description { get; set; }
        [Required]
        public int Inventory { get; set; }
    }
}