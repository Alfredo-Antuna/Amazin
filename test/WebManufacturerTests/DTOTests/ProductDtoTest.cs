using System;
using Xunit;
using WebManufacturer;
using FluentAssertions;


namespace test
{
    public class ProductDtoTest
    {
        [Fact]
        public void ShouldCreateProductDto()
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            testProductDto.Name.Should().Be("TestProduct");
            testProductDto.Price.Should().Be(500);
            testProductDto.Weight.Should().Be(2.5);
            testProductDto.Description.Should().Be("Test description");
            testProductDto.Inventory.Should().Be(20);
        }
    }
}