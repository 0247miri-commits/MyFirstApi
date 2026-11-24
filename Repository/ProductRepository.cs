using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly storeDBContext _context;
        public ProductRepository(storeDBContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductFromDb(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.id == id);
        }



    }
}
