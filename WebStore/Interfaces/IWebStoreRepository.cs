using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStore
{
    public interface IWebStoreRepository
    {
        Task SaveAsync(); //pass
        Task AddUserAsync(User user); //pass
        Task SendMessageAsync(MessageDto messageDto); //pass
        Task<IEnumerable<Message>> GetMessagesAsync(Guid userId);
        Task<IEnumerable<ProductDetail>> GetStoreInventoryAsync();
        Task AddOrderAsync(Order order);
        Task AddOrderDetailAsync(OrderDetail orderdetail);
        Task<IEnumerable<Order>> GetAllOrdersAsync(Guid userId);
        Task CheckoutAsync(Order order);
        Task UserAnalyticsAsync(Guid userId);
        Task<IEnumerable<ProductDetail>> AdminAnalyticsAsync();



    }
}