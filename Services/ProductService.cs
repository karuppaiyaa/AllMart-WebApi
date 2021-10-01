using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Repositories;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository = new ProductRepository();

        public async Task Create(Product product)
        {
            await productRepository.Create(product);
        }

        public async Task<List<Product>> GetAllSearchAsync(string search)
        {
            return await productRepository.GetAllSearchAsync(search);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public async Task<Product> GetById(string Id)
        {
            return await productRepository.GetById(Id);
        }
    }
}
