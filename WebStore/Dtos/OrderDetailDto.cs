using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore
{
    public class OrderDetailDto
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid ProductId { get; set; }

    }
}