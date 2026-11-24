using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product?> GetProductFromDb(int id);
    }
}