using System;
using Xunit;
using WebManufacturer;
using FluentAssertions;


namespace test
{
    public class ProductTest
    {
        [Fact]
        public void ShouldCreateProduct()
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            Product testProduct = new(testProductDto);
            testProduct.Name.Should().Be("TestProduct");
            testProduct.Price.Should().Be(500);
            testProduct.Weight.Should().Be(2.5);
            testProduct.Description.Should().Be("Test description");
            testProduct.Inventory.Should().Be(20);
        }
    }
}