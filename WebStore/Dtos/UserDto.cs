using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore
{
    public class UserDto
    {
        [Required]
        public string UserName {get; set;}

    }
}