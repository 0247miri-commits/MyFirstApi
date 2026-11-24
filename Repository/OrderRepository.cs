using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly storeDBContext _context;
        public OrderRepository(storeDBContext context)
        {
            _context = context;
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

            return await GetOrderItems(order.id);
        }
    }

}

