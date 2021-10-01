using AllMart_WebApi.Common;
using AllMart_WebApi.Configuration;
using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Queries;
using Dapper;
using MediatR;
using MediatR.Extensions.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;


namespace AllMart_WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _product;
        public ProductRepository()
         {
             var client = new MongoClient("mongodb://localhost:27017");
             var database = client.GetDatabase("AllMartDB");
             _product = database.GetCollection<Product>("Products");
        }
    
        public async Task Create(Product product)
        {
            product.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            await _product.InsertOneAsync(product);
        }

        public async Task<List<Product>> GetAllSearchAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _product.Find(c => true).ToListAsync();
            else
                return await _product.Find(c => (c.name.ToLower().Contains(search.ToLower()) || c.description.ToLower().Contains(search.ToLower()) || c.tags.ToLower().Contains(search.ToLower()))).ToListAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
                return await _product.Find(c => true).ToListAsync();
        }

        public async Task<Product> GetById(string Id)
        {
            return await Task.FromResult(_product.Find(c => c.Id == Id).FirstOrDefault());
        }
    }
}
