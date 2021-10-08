using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore
{
    public class MessageDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid FromUser { get; set; }
        [Required]
        public Guid ToUser { get; set; }
    }
}