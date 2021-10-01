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
    public class SettingsRepository : ISettingsRepository
    {
        public async Task<Settings> Get()
        {
            using (IDbConnection connectionPostgreSQL = new NpgsqlConnection(Global.ConnectionStringPostgreSQL))
            {
                var querySQL = @"SELECT * FROM public.settings;";
                return await Task.FromResult(connectionPostgreSQL.Query<Settings>(querySQL).FirstOrDefault());
            }
        }

    }
}
