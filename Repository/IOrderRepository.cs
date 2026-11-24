using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<ICollection<Order_Item>> GetOrderItems(int id);
        Task<ICollection<Order_Item>> InsertOrderToDB(Order order);
    }
}