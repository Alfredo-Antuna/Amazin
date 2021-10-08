using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace WebStore
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public List<Order> Orders { get; set; } = new();
        [InverseProperty("FromUser")]
        public List<Message> SentMessages { get; set; } = new();
        [InverseProperty("ToUser")]
        public List<Message> ReceivedMessages { get; set; } = new();

        public User() {  Id = new Guid();}

        public User(UserDto userDto): this()
        {
          
            Username = userDto.UserName;
        }
    }
}