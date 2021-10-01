using AllMart_WebApi.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllSearchAsync(string search);
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetById(string Id);
        public Task Create(Product product);
    }
}
