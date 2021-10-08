using System;
namespace WebStore
{
    public class OrderDetail
    {
        public Guid Id { get; set;}
        public Guid ProductId {get; set;}
        public int Quantity {get; set;}
        public Order Order {get; set;}
        public OrderDetail () { }
        public OrderDetail(OrderDetailDto orderDetailDto)
        {
           Quantity = orderDetailDto.Quantity;
           ProductId = orderDetailDto.ProductId;
        }

    }
}