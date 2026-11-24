using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        // יצירת מופע של UserRepository עם IUserRepository
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<Product>> GetProductListByCategory(int id)
        {
            return await _repository.GetCategoryFromDb(id);
        }

    }
}
