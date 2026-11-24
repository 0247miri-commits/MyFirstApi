using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly storeDBContext _context;
        public CategoryRepository(storeDBContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Product>> GetCategoryFromDb(int id)
        {

            var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.id == id);

            return category?.Products.ToList() ?? new List<Product>();
        }


    }
}
