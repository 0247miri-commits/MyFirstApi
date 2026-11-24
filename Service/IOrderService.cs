using Entities;

namespace Service
{
    public interface IOrderService
    {
        Task<ICollection<Order_Item>> InsertOrderToDB(Order order);
        Task<ICollection<Order_Item>> GetOrderItems(int id);

    }
}