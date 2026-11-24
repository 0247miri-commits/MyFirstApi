using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<Product?> GetProduct(int id);
    }
}