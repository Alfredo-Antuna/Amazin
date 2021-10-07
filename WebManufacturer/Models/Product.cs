using System;
namespace WebManufacturer
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }

        public Product() { }

        public Product(ProductDto productDto)
        {
            Id = new Guid();
            Name = productDto.Name;
            Price = productDto.Price;
            Weight = productDto.Weight;
            Inventory = productDto.Inventory;
            Description = productDto.Description;
        }
    }
}