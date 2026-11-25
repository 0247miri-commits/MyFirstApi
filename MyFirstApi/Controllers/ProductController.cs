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
        private readonly ILogger<ProductController> logger;
        private IProductService _service;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _service = productService;
            this.logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {(List<Product> Items, int TotalCount)  = await _service.GetProducts(position,skip,desc,minPrice,maxPrice,categoryIds);
            if (Items.Count>0)
                return Ok(Items);
            return NotFound("A product hadn't found");

        }
    }
}
