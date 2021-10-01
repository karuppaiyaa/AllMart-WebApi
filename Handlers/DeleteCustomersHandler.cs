using AllMart_WebApi.Models;
using AllMart_WebApi.Queries;
using MediatR;
using System;
using Dapper;
using AllMart_WebApi.Common;
using System.Data;
using MediatR.Extensions.Microsoft.DependencyInjection;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllMart_WebApi.Commands;
using AllMart_WebApi.Interfaces;

namespace AllMart_WebApi.Handlers
{
    public class DeleteCustomersHandler : IRequestHandler<DeleteCustomersCommand, int>
    {
        private readonly ICustomerMongoService customerService;

        public DeleteCustomersHandler(ICustomerMongoService customerService)
        {
            this.customerService = customerService;
        }

        public async Task<int> Handle(DeleteCustomersCommand request, CancellationToken cancellationToken)
        {
            await customerService.DeleteAsync(request.id);
            return 1;
        }
    }
}
