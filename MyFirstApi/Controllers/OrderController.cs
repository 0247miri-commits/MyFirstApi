using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;


namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;
        public OrderController(IOrderService orderService)
        {
            _service = orderService;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
           ICollection<Order_Item> order_Item = await _service.GetOrderItems(id);
            if (!order_Item.IsNullOrEmpty())
                return Ok(order_Item);
            return NotFound("An order does'nt exist in system");
            
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Order order)
        {
            if (order == null)
                return BadRequest("No items found in that order");
            ICollection<Order_Item> order_Item = await _service.InsertOrderToDB(order);

            if (!order_Item.IsNullOrEmpty())
                return Ok(order_Item);
            return NotFound("An order does'nt exist in system");

        }
    }
}


    
