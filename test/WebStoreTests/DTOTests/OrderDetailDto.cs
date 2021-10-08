using System;
using Xunit;
using WebStore;
using FluentAssertions;


namespace test.WebStoreTests
{
    public class OrderDetailDtoTest
    {
        [Fact]
        public void ShouldCreateOrderDetailDto()
        {
        Guid ProductId = new Guid();
        OrderDetailDto testOrderDetailDto = new() { Quantity = 2, ProductId = ProductId };
        testOrderDetailDto.Quantity.Should().Be(2);
        testOrderDetailDto.ProductId.Should().Be(ProductId);
    }
}}