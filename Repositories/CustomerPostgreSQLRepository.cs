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
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;


namespace AllMart_WebApi.Repositories
{
    public class CustomerPostgreSQLRepository : ICustomerPostgreSQLRepository
    {
        public async Task<long> Create(CustomerData customer)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@firstName", customer.firstName);
                param.Add("@lastName", customer.lastName);
                param.Add("@address1", customer.address1);
                param.Add("@address2", customer.address2);
                param.Add("@place", customer.place);
                param.Add("@pincode", customer.pincode);
                param.Add("@email", customer.email);
                param.Add("@mobileNumber", customer.mobileNumber);
                param.Add("@customerType", customer.customerType);
                long result = await Task.FromResult(connectionPostgreSQL.Execute($"insert into public.allmartdb values(default, default, @firstName, @lastName, @address1, @address2, @place, @pincode, @email, @mobileNumber, @customerType)", param, commandType: CommandType.Text));
                return result;
            }
        }

        public async Task<long> DeleteAsync(long id)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@key", id);
                long result = await Task.FromResult(connectionPostgreSQL.Execute($"DELETE FROM public.allmartdb WHERE key = @key",param, commandType: CommandType.Text));
                return result;
            }
        }

        public Task<List<CustomerData>> GetAllAsync()
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var querySQL = @"SELECT * FROM public.allmartdb;";
                IList<CustomerData> customerList =  connectionPostgreSQL.Query<CustomerData>(querySQL).ToList();
                return Task.FromResult(customerList.ToList());
            }
        }

        public Task<CustomerData> GetByIdAsync(long id)
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var param = new DynamicParameters();
                param.Add("@key", id);
                var result = connectionPostgreSQL.Query<CustomerData>(@"Select * from public.allmartdb Where key = @key", param, commandType: CommandType.Text).FirstOrDefault();
                return Task.FromResult(result);
            }
        }

        public async Task<long> Update(long id, CustomerData customer)
        {
            if (id == customer.key)
            {
                using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
                {
                    var param = new DynamicParameters();
                    param.Add("@firstName", customer.firstName);
                    param.Add("@lastName", customer.lastName);
                    param.Add("@address1", customer.address1);
                    param.Add("@address2", customer.address2);
                    param.Add("@place", customer.place);
                    param.Add("@pincode", customer.pincode);
                    param.Add("@email", customer.email);
                    param.Add("@mobileNumber", customer.mobileNumber);
                    param.Add("@customerType", customer.customerType);
                    long result = await Task.FromResult(connectionPostgreSQL.Execute($"Update public.allmartdb set firstName = @firstName,lastName = @lastName,address1 = @address1,address2 = @address2,place = @place,pincode = @pincode,email = @email,mobileNumber = @mobileNumber,customerType = @customerType", param, commandType: CommandType.Text));
                    return result;
                }
            }
            return 0;
        }
    }
}
