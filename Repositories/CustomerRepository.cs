using AllMart_WebApi.Common;
using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Queries;
using Dapper;
using MediatR;
using MediatR.Extensions.Microsoft.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMediator mediator;

        public CustomerRepository(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //SQL
        public async Task<List<CustomerGetDetails>> FindCustomer(string search)
        {
            var getAllQuery = new GetAllCustomersQuery(search);
            var result = await mediator.Send(getAllQuery);
            return result;
        }

    }
}
