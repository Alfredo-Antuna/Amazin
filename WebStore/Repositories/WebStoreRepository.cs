using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
namespace WebStore
{
    public class WebStoreRepository : IWebStoreRepository
    {
        private Database _db;
        public WebStoreRepository(Database db)
        {
            _db = db;
        }
        public Task AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task AddOrderDetailAsync(OrderDetail orderdetail)
        {
            throw new NotImplementedException();
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDetail>> AdminAnalyticsAsync()
        {
            throw new NotImplementedException();
        }

        public Task CheckoutAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task GetMessageAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDetail>> GetStoreInventoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync(MessageDto messageDto)
        {
            throw new NotImplementedException();
        }

        public Task UserAnalyticsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}