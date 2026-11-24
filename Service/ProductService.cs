using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        // יצירת מופע של UserRepository עם IUserRepository
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product?> GetProduct(int id)
        {
            return await _repository.GetProductFromDb(id);
        }


    }
}
