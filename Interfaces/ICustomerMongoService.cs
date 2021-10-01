using AllMart_WebApi.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Interfaces
{
    public interface ICustomerMongoService
    {
        public Task<List<Customer>> GetAllAsync(string search);
        public Task<Customer> GetByIdAsync(int id);
        public Task Create(Customer customer);
        public void Update(string id, Customer customer);
        public Task DeleteAsync(int id);

    }
}
