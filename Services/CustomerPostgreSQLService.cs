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
    public class CustomerPostgreSQLService : ICustomerPostgreSQLService
    {
        private readonly CustomerPostgreSQLRepository customerRepository = new CustomerPostgreSQLRepository();

        public async Task<long> Create(CustomerData customer)
        {
            return await customerRepository.Create(customer);
        }

        public async Task<long> DeleteAsync(long id)
        {
            return await customerRepository.DeleteAsync(id);
        }

        public async Task<List<CustomerData>> GetAllAsync()
        {
            return await customerRepository.GetAllAsync();
        }

        public async Task<CustomerData> GetByIdAsync(long id)
        {
            return await customerRepository.GetByIdAsync(id);
        }

        public Task<long> Update(long id, CustomerData customer) => customerRepository.Update(id, customer);
    }
}
