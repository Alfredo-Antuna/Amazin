using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace WebManufacturer
{

    [ApiController]
    [Route("api/products")]
    public class WebManufacturerController : ControllerBase
    {
        private IWebManufacturerRepository _repository;

        public WebManufacturerController(IWebManufacturerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost] //"api/products"
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var product = new Product(productDto);
            await _repository.AddAsync(product);
            await _repository.SaveAsync();

            return CreatedAtAction("GetOne", new { product.Id }, product);
        }

        [HttpGet("{id}")] // "api/products/{id}
        public async Task<IActionResult> GetOne(Guid id)
        {
            var product = await _repository.SearchByIdAsync(id);
            return Ok(product);
        }

        [HttpGet] //"api/products"
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost("add/{productGuid}/{quantity}")] //"add/{productGuid}/{quantity}"
        public async Task<IActionResult> AddInventory(Guid productGuid, int quantity)
        {
            await _repository.AddInventoryAsync(productGuid, quantity);
            var product = await _repository.SearchByIdAsync(productGuid);
            return Ok(product);
        }

        [HttpPost("subtract/{productGuid}/{quantity}")] //"subtract/{productGuid}/{quantity}"
        public async Task<IActionResult> SubtractInventory(Guid productGuid, int quantity)
        {
            await _repository.SubtractInventoryAsync(productGuid, quantity);
            var product = await _repository.SearchByIdAsync(productGuid);
            return Ok(product);
        }
    }
}