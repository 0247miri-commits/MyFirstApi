using Entities;

namespace Service
{
    public interface ICategoryService
    {
        Task<ICollection<Product>> GetProductListByCategory(int id);
    }
}