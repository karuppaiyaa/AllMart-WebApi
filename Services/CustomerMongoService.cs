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
    public class CustomerMongoService : ICustomerMongoService
    {
        private readonly ICustomerMongoRepository customerRepository;

        public CustomerMongoService(ICustomerMongoRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task Create(Customer customer)
        {
            await customerRepository.Create(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await customerRepository.DeleteAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync(string search)
        {
            return await customerRepository.GetAllAsync(search);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await customerRepository.GetByIdAsync(id);
        }

        public void Update(string id, Customer customer) => customerRepository.Update(id, customer);
    }
}
