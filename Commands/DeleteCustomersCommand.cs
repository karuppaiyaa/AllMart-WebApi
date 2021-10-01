using AllMart_WebApi.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Commands
{
    public class DeleteCustomersCommand : IRequest<int>
    {
        public int id { get; set; }
        public DeleteCustomersCommand(int id)
        {
            this.id = id;
        }
    }
}
