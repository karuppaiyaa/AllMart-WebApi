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
    public class BillsRepository : IBillsRepository
    {
        private readonly IMongoCollection<Bills> _bills;
        public BillsRepository()
         {
             var client = new MongoClient("mongodb://localhost:27017");
             var database = client.GetDatabase("AllMartDB");
             _bills = database.GetCollection<Bills>("Bills");
        }
    
        public async Task Create(Bills bills)
        {
            bills.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            await _bills.InsertOneAsync(bills);
        }

        public async Task<Bills> GetById(string Id)
        {
            return await Task.FromResult(_bills.Find(c => c.Id == Id).FirstOrDefault());
        }
    }
}
