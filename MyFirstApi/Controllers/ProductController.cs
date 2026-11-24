using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Service;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService productService)
        {
            _service = productService;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _service.GetProduct(id);
            if (product != null)
                return Ok(product);
            return NotFound("A product hadn't found");

        }
    }
}
