using System;
using Xunit;
using WebStore;
using FluentAssertions;

namespace test
{
public class UserTest
{
    [Fact]
    public void ShouldCreateUser()
    {
        UserDto testUserDto = new() {Username = "Bruce Lee"};
        User testUser = new(testUserDto);
        testUser.Username.Should().Be("Bruce Lee");
    }
}
}