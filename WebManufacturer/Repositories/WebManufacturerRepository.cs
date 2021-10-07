using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace WebManufacturer
{
    public class WebManufacturerRepository : IWebManufacturerRepository
    {
        private Database _db;

        //constructor
        public WebManufacturerRepository(Database db)
        {
            _db = db;
        }

        //add product
        public async Task AddAsync(Product product)
        {
            await _db.AddAsync(product);
            await SaveAsync();
        }
        //save changes
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        //add inventory
        public async Task AddInventoryAsync(Guid productGuid, int quantity)
        {
            var product = _db.Products.Where(p => p.Id == productGuid).FirstOrDefault();
            if (product == null)
                return;
            product.Inventory += quantity;
            await SaveAsync();
        }

        //subtract inventory
        public async Task SubtractInventoryAsync(Guid productGuid, int quantity)
        {
            var product = _db.Products.Where(p => p.Id == productGuid).FirstOrDefault();
            if (product == null)
                return;
            product.Inventory -= quantity;
            await SaveAsync();
        }

        //get one product
        public async Task<Product> SearchByIdAsync(Guid id)
        {
            return await _db.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
        }

        //get all products in stock
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

    }
}