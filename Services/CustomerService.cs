using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Services
{
    public class CustomerService : ICustomerService
    {
        //private readonly CustomerRepository customerRepository = new CustomerRepository();
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        //sql
        public async Task<List<CustomerGetDetails>> FindCustomer(string search)
        {
            return await customerRepository.FindCustomer(search);
        }

    }
}
