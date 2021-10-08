using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore
{
    public class MessageDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public User FromUser { get; set; }
        [Required]
        public User ToUser { get; set; }
    }
}