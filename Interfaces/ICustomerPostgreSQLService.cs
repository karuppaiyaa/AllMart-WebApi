using AllMart_WebApi.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Interfaces
{
    public interface ICustomerPostgreSQLService
    {
        public Task<List<CustomerData>> GetAllAsync();
        public Task<CustomerData> GetByIdAsync(long id);
        public Task<long> Create(CustomerData customer);
        public Task<long> Update(long id, CustomerData customer);
        public Task<long> DeleteAsync(long id);

    }
}
