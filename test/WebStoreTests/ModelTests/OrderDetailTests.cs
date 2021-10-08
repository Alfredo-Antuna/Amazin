using System;
using Xunit;
using WebStore;
using FluentAssertions;

namespace test
{
    public class OrderDetailTest
    {
        [Fact]
        public void ShouldCreateOrderDetail()
        {
            Guid ProductId = new Guid();
            OrderDetailDto testOrderDetailDto = new() { Quantity = 2, ProductId = ProductId };
            OrderDetail testOrderDetail = new(testOrderDetailDto);
            testOrderDetail.Quantity.Should().Be(2);
            testOrderDetail.ProductId.Should().Be(ProductId);
        }
    }
}