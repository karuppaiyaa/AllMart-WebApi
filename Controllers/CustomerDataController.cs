using AllMart_WebApi.Filters;
using AllMart_WebApi.Interfaces;
using AllMart_WebApi.Models;
using AllMart_WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR.Extensions.Microsoft.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AllMart_WebApi.Controllers
{
    //[CustomExceptionFilter]
    [Route("CustomerPostgreSQL")]
    [ApiController]
    public class CustomerDataController : ControllerBase
    {
        public readonly ICustomerPostgreSQLService customerPostgreSQLService = new CustomerPostgreSQLService();

        //[FromQuery]
        //public string searchOptional { get; set; }
        //mongo
     //  public CustomerDataController(ICustomerPostgreSQLService customerPostgreSQLService)
       // {
         //   this.customerPostgreSQLService = customerPostgreSQLService;
       // }

        //POSTGRESQL
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await customerPostgreSQLService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var customer = await customerPostgreSQLService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerData customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await customerPostgreSQLService.Create(customer);
            return Ok(customer.key);
        }

        [HttpPut("{id}")]
        public void PutCustomer(long id, [FromBody] CustomerData customer)
        {
            //var objectId = new ObjectId(id);
            customerPostgreSQLService.Update(id, customer);

        }
        [HttpDelete("{id}")]
        public async Task<long> DeleteCustomer(long id)
        {
            var customer = await customerPostgreSQLService.GetByIdAsync(id);
            if (customer == null)
            {
                return 0;
            }
            return await customerPostgreSQLService.DeleteAsync(customer.key);
        }
    }
}
