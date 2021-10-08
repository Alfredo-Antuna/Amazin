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
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        public async Task AddUserAsync(User user) //passes
        {
            await _db.AddAsync(user);
            await SaveAsync();
        }

        public async Task SendMessageAsync(MessageDto messageDto) //passes
        {
            //query user database 
            var fromUser = _db.Users.Where(user => user.Id == messageDto.FromUser).FirstOrDefault();
            var toUser = _db.Users.Where(user => user.Id == messageDto.ToUser).FirstOrDefault();
            Message newMessage = new() { FromUser = fromUser, ToUser = toUser, Text = messageDto.Text };
            await _db.Messages.AddAsync(newMessage);
            await SaveAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(Guid userId) //fails
        {
            return await _db.Messages.ToListAsync();
            //not finished
        }

        public async Task<IEnumerable<ProductDetail>> GetStoreInventoryAsync()
        {
            var client = new HttpClient();
            var products = new List<ProductDetail>();
            try
            {
                products = await client.GetFromJsonAsync<List<ProductDetail>>($"http://localhost:5001/api/products");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error : {ex.Message}");
            }
            return products;
        }


        public Task AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task AddOrderDetailAsync(OrderDetail orderdetail)
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




        public Task UserAnalyticsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}