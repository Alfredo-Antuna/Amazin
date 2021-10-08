using System;
using Xunit;
using WebStore;
using FluentAssertions;


namespace test
{
    public class MessageDtoTest
    {
        [Fact]
        public void ShouldCreateMessageDto()
        {
            User user1 = new User();
            user1.Username = "Bruce Lee";
            User user2 = new User();
            user2.Username = "Bruce Willis";
            MessageDto testMessageDto = new() { Text = "Hi", FromUser = user1, ToUser = user2 };
            testMessageDto.Text.Should().Be("Hi");
            testMessageDto.FromUser.Username.Should().Be("Bruce Lee");
            testMessageDto.ToUser.Username.Should().Be("Bruce Willis");
        }
    }
}