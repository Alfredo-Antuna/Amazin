using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStore
{
    public interface IWebStoreRepository
    {
        Task SaveAsync();
        Task AddUserAsync(User user);
        Task SendMessageAsync(MessageDto messageDto);
        Task GetMessageAsync(Guid userId);
        Task<IEnumerable<ProductDetail>> GetStoreInventoryAsync();
        Task AddOrderAsync(Order order);
        Task AddOrderDetailAsync(OrderDetail orderdetail);
        Task<IEnumerable<Order>> GetAllOrdersAsync(Guid userId);
        Task CheckoutAsync(Order order);
        Task UserAnalyticsAsync(Guid userId);
        Task <IEnumerable<ProductDetail>> AdminAnalyticsAsync ();



    }
}