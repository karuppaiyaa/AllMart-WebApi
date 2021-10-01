using AllMart_WebApi.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerGetDetails>>
    {
        public string search { get; set; }
        public GetAllCustomersQuery(string search)
        {
            this.search = search;
        }
    }
}
