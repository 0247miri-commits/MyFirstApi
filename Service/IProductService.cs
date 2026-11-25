using Entities;

namespace Service
{
    public interface IProductService
    {

        Task<(List<Product> Items, int TotalCount)> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}