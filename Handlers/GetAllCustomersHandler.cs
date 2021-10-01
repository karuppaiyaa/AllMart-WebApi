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

namespace AllMart_WebApi.Handlers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerGetDetails>>
    {
        public Task<List<CustomerGetDetails>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            using (IDbConnection connectionSQL = new SqlConnection(Global.ConnectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@searchvalue", request.search);
                IList<CustomerGetDetails> customerList = SqlMapper.Query<CustomerGetDetails>(
                                  connectionSQL, "FindCustomer", param, commandType: CommandType.StoredProcedure).ToList();
                return Task.FromResult(customerList.ToList());
            }
        }
    }
}
