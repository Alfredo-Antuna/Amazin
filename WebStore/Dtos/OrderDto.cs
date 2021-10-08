using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore
{
    public class OrderDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public User User { get; set; }
    }
}