using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }


        public async Task<ICollection<Order_Item>> InsertOrderToDB(Order order)
        {
            return await _repository.InsertOrderToDB(order);
        }

        public async Task<ICollection<Order_Item>> GetOrderItems(int id)
        {
            return await _repository.GetOrderItems(id);
        }

    }
}
