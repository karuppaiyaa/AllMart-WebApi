using AllMart_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<CustomerGetDetails>> FindCustomer(string search);

    }
}
