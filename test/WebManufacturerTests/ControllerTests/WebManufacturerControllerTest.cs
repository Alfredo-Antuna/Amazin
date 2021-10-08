using System;
using Xunit;
using FluentAssertions;
using lib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebManufacturer;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace test
{
    public class WebManufacturerControllerTest
    {
        private WebManufacturerController _controller;
        private Mock<IWebManufacturerRepository> _mockRepository;
        private DefaultHttpContext _httpContext;

        //constructor
        public WebManufacturerControllerTest()
        {
            _mockRepository = new Mock<IWebManufacturerRepository>();
            _httpContext = new DefaultHttpContext();
            _controller = new WebManufacturerController(_mockRepository.Object)
            { ControllerContext = new ControllerContext() { HttpContext = _httpContext } };
        }

        [Fact]
        public async Task ShouldCreateProduct() //pass
        {
            ProductDto testProductDto = new() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 };
            var result = await _controller.Create(testProductDto);
            var createdActionResult = result as CreatedAtActionResult;
            createdActionResult.StatusCode.Should().Be(201);
            createdActionResult.ActionName.Should().Be("GetOne");
            createdActionResult.RouteValues["Id"].Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldGetOneProduct() //pass
        {
            Guid guid = Guid.NewGuid();
            _mockRepository.Setup(obj => obj.SearchByIdAsync(guid)).Returns(Task.FromResult(new Product() { Name = "TestProduct", Price = 500, Weight = 2.5, Description = "Test description", Inventory = 20 }));
            var result = await _controller.GetOne(guid);
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
            (okResult.Value as Product).Name.Should().Be("TestProduct");
            _mockRepository.Verify(obj => obj.SearchByIdAsync(guid));
        }

        [Fact]
        public async Task ShouldGetAllProducts() //pass
        {
            var result = await _controller.GetAll();
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
            _mockRepository.Verify(obj => obj.GetAllAsync());
        }

        [Fact]
        public async Task ShouldAddInventory() //pass
        {
            Guid testGuid = new();
            var result = await _controller.AddInventory(testGuid, 5);
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
            _mockRepository.Verify(obj => obj.AddInventoryAsync(testGuid, 5));
        }

        [Fact]
        public async Task ShouldSubtractInventory() //pass
        {
            Guid testGuid = new();
            var result = await _controller.SubtractInventory(testGuid, 5);
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
            _mockRepository.Verify(obj => obj.SubtractInventoryAsync(testGuid, 5));
        }


    }
}