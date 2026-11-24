using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Entities;
using Service;
using System.Threading.Tasks.Dataflow;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        

      
            private ICategoryService _service;
            public CategoryController(ICategoryService categoryService)
            {
                _service = categoryService;

            }

            [HttpGet("{id}")]
            public async Task<ActionResult<ICollection<Product>>> Get(int id)
            {
                ICollection<Product> products = await _service.GetProductListByCategory(id);
                if (products != null)
                    return Ok(products);
                return NotFound("No products exist for that category");

            }
        }


    
}
