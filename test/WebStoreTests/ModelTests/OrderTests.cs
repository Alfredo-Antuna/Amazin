using System;
using Xunit;
using WebStore;
using FluentAssertions;

namespace test
{
    public class OrderTest
    {
        [Fact]
        public void ShouldCreateOrder()
        {
            User user1 = new User();
            user1.Username = "Bruce Lee";
            OrderDto testOrderDto = new() {Date = DateTime.Now, User = user1};
            Order testOrder = new(testOrderDto);
            testOrder.User.Username.Should().Be("Bruce Lee");
        }
    }
}