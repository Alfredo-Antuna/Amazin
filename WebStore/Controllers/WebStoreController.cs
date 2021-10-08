using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace WebStore
{
    [ApiController]
    [Route("api/webstore")]
    public class WebStoreController : ControllerBase
    {
        private IWebStoreRepository _repository;

        public WebStoreController(IWebStoreRepository repository)
        {
            _repository = repository;
        }
        [HttpGet] //"api/products"

        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetStoreInventoryAsync();
            return Ok(products);
        }
    }
}