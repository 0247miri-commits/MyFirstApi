using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Product>> GetCategoryFromDb(int id);
    }
}