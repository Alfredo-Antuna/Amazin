using System;
using System.Collections.Generic;
namespace WebStore
{
    public class Order
    {
           public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new();
        public User User { get; set; }
        public bool Fulfilled { get; set; } = false;
        public Order(){Id = new Guid();}
        public Order (OrderDto orderDto): this ()
        {
            Date = orderDto.Date;
            User = orderDto.User;
        }
    }
}