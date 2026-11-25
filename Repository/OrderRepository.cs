using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly storeDBContext _context;
        private readonly ILogger<OrderRepository> logger;

        public OrderRepository(storeDBContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            this.logger = logger;
        }


        public async Task<ICollection<Order_Item>> GetOrderItems(int id)
        {
            return await _context.Order_Items
                .Where(item => item.order_id == id)
                .ToListAsync();
        }


      
           public async Task<ICollection<Order_Item>> InsertOrderToDB(Order order)
        {
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
            logger.LogInformation($"An Order inserted to the system : {order.id}");

            return await GetOrderItems(order.id);

        }
    }

}

