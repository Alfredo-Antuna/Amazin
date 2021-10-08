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
            MessageDto testMessageDto = new() { Text = "Hi", FromUser = user1.Id, ToUser = user2.Id };
            testMessageDto.Text.Should().Be("Hi");
            testMessageDto.FromUser.Should().Be(user1.Id);
            testMessageDto.ToUser.Should().Be(user2.Id);
        }
    }
}