using AllMart_WebApi.Common;
using AllMart_WebApi.Configuration;
using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Queries;
using Dapper;
using MediatR;
using MediatR.Extensions.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Runtime.Serialization.Json;
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
    public class CustomerMongoRepository : ICustomerMongoRepository
    {
        private readonly IMongoCollection<Customer> _customer;
        //private readonly CustomerConfiguration _settings;
        //MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        public CustomerMongoRepository()
         {
             var client = new MongoClient("mongodb://localhost:27017");
             var database = client.GetDatabase("AllMartDB");
             _customer = database.GetCollection<Customer>("Customers");
            _server = client.GetServer();
            _db = _server.GetDatabase("AllMartDB");
        }


        public async Task Create(Customer customer)
        {
            int LastCustomerId = _customer.AsQueryable().Count();
            //customer.key = (int)_db.Eval(new EvalArgs { Code = @"getUnique('Customer_id')" });
            customer.key = LastCustomerId + 1;
            //customer.key = (int)_db.Eval(new EventArgs { Code = new BsonJavaScript("getUnique(Customer_id)") }};);
            customer.version = 1.0;
            //customer.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            //_db.GetCollection<Customer>("Customers").Save(customer);
            await _customer.InsertOneAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _customer.DeleteOneAsync(c => c.key == id);
        }

        public async Task<List<Customer>> GetAllAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return await _customer.Find(c => true).ToListAsync();
            else
            {
                //var filter = Builders<Customer>.Filter.Where(c => c.name.ToLower().Contains(search.ToLower()));
                return await _customer.Find(c => c.name.ToLower().Contains(search.ToLower())).ToListAsync();

            }
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customer.Find<Customer>(c => c.key == id).FirstOrDefaultAsync();
        }

        public void Update(string id, Customer customer)
        {
            customer.Id = id;
            var res = Query<Customer>.EQ(pd => pd.Id, id);
            customer.version = customer.version + 0.1;
            var operation = Update<Customer>.Replace(customer);
            _db.GetCollection<Customer>("Customers").Update(res, operation);
        }
    }
}
