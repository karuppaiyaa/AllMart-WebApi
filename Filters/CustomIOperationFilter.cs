using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Filters
{
    public class CustomIOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {/*
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "searchOptional",
                In = ParameterLocation.Query,
                Description = "Search Value",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "pageNumber",
                In = ParameterLocation.Query,
                Description = "pageNumber",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "pageSize",
                In = ParameterLocation.Query,
                Description = "pageSize",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });*/
        }
    }
}
