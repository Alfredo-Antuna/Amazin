using System;
using Xunit;
using WebManufacturer;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace test
{
    public class WebManufacturerRepositoryTest
    {
        private Database _db;
        private IWebManufacturerRepository _repo;

        public WebManufacturerRepositoryTest()
        {
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();
            var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
            _db = new Database(options);
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _repo = new WebManufacturerRepository(_db);
        }

        [Fact]
        public async Task ShouldSaveProductToDatabase() //pass
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            Product testProduct = new(testProductDto);
            await _repo.AddAsync(testProduct);
            _db.Products.Count().Should().Be(1);
        }

        [Fact]
        public async Task ShouldAddProductInventoryCount() //pass
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            Product testProduct = new(testProductDto);
            await _repo.AddAsync(testProduct);
            await _repo.AddInventoryAsync(testProduct.Id, 10);
            _db.Products.First().Inventory.Should().Be(30);
        }
        [Fact]
        public async Task ShouldSubtractProductInventoryCount() //pass
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            Product testProduct = new(testProductDto);
            await _repo.AddAsync(testProduct);
            await _repo.SubtractInventoryAsync(testProduct.Id, 8);
            _db.Products.First().Inventory.Should().Be(12);
        }

        [Fact]
        public async Task ShouldGetOneProduct() //pass
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            Product testProduct = new(testProductDto);
            ProductDto testProductDto2 = new() { Name = "TestProduct2", Price = 400, Weight = 2, Description = "Test description2", Inventory = 25 };
            Product testProduct2 = new(testProductDto2);
            testProduct.Id = Guid.Parse("f104f46e-fcc6-4e57-bb06-435944e33e6b");
            await _repo.AddAsync(testProduct);
            await _repo.AddAsync(testProduct2);

            var result = await _repo.SearchByIdAsync(Guid.Parse("f104f46e-fcc6-4e57-bb06-435944e33e6b"));
            result.Id.ToString().Should().Be("f104f46e-fcc6-4e57-bb06-435944e33e6b");
            result.Name.Should().Be("TestProduct");
            result.Price.Should().Be(500);
        }

        [Fact]
        public async Task ShouldGetAllProducts() //pass
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            Product testProduct = new(testProductDto);
            ProductDto testProductDto2 = new() { Name = "TestProduct2", Price = 400, Weight = 2, Description = "Test description2", Inventory = 25 };
            Product testProduct2 = new(testProductDto2);
            await _repo.AddAsync(testProduct);
            await _repo.AddAsync(testProduct2);

            var products = await _repo.GetAllAsync();
            products.Should().HaveCount(2);
        }
    }
}
