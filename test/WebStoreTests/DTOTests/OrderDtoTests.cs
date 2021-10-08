using System;
using Xunit;
using WebStore;
using FluentAssertions;


namespace test.WebStoreTests
{
    public class OrderDtoTest
    {
        [Fact]
        public void ShouldCreateOrderDto()
        {
            User user1 = new User();
            user1.Username = "Bruce Lee";
            OrderDto testOrderDto = new() { Date = DateTime.Now, User = user1 };
            Order testOrder = new(testOrderDto);
            testOrderDto.User.Username.Should().Be("Bruce Lee");
        }
    }
}