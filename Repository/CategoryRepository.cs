using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> logger;
        private readonly storeDBContext _context;
        public CategoryRepository(storeDBContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            this.logger = logger;
        }
        public async Task<ICollection<Product>> GetCategoryFromDb(int id)
        {
            var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.id == id);
            logger.LogInformation($"Getting Products according to category : {category.category_name}");


            return category?.Products.ToList() ?? new List<Product>();
        }


    }
}
