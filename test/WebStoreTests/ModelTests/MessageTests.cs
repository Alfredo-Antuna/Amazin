using System;
using Xunit;
using WebStore;
using FluentAssertions;

namespace test
{
    public class MessageTest
    {
        [Fact]
        public void ShouldCreateMessage()
        {
            User user1 = new User();
            user1.Username = "Bruce Lee";
            User user2 = new User();
            user2.Username = "Bruce Willis";
            Message testMessage = new() { Id = new Guid(), FromUser = user1, ToUser = user2, Text = "Hi" };
            testMessage.Text.Should().Be("Hi");
            testMessage.FromUser.Username.Should().Be("Bruce Lee");
            testMessage.ToUser.Username.Should().Be("Bruce Willis");
        }
    }
}