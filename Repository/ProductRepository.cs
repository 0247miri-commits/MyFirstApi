using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly storeDBContext _context;
        public ProductRepository(storeDBContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            this._logger = logger;
        }

       

        public async Task<(List<Product> Items, int TotalCount)> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice,
    int?[] categoryIds)

        {
            _logger.LogInformation("Get Products for user");
            var query = _context.Products.Where(product =>
                (desc == null ? (true) : (product.description.Contains(desc)))
                && ((minPrice == null) ? (true) : (product.price >= minPrice))
                && ((maxPrice == null) ? (true) : (product.price <= maxPrice))
                && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.category_id))))
                .OrderBy(product => product.price);

            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.Skip((position - 1) * skip)
                .Take(skip).Include(product => product.category).ToListAsync();
            var total = await query.CountAsync();
            return (products, total);
        }
      
    }


    
}
