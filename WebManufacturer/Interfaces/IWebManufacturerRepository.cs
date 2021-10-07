using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebManufacturer
{
    public interface IWebManufacturerRepository
    {
        Task AddAsync(Product product); //tested
        Task SaveAsync(); //tested
        Task<Product> SearchByIdAsync(Guid id); //tested
        Task<IEnumerable<Product>> GetAllAsync(); //tested
        Task AddInventoryAsync(Guid productGuid, int quantity); //tested
        Task SubtractInventoryAsync(Guid productGuid, int quantity); //tested
    }
}