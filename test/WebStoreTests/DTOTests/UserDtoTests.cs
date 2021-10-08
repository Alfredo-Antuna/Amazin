using System;
using Xunit;
using WebStore;
using FluentAssertions;


namespace test
{
    public class UserDtoTest
    {
        [Fact]
        public void ShouldCreateUserDto()
        {
            UserDto testUserDto = new(){Username = "Bruce Lee"};
        testUserDto.Username.Should().Be("Bruce Lee");
        }

    }}