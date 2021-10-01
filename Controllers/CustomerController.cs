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
using MediatR;
using AllMart_WebApi.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AllMart_WebApi.Controllers
{
    //[CustomExceptionFilter]
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        //sql
        private readonly ICustomerService customerSQLService;
        private readonly ICustomerMongoService customerService;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator mediator;

        //[FromQuery]
        //public string searchOptional { get; set; }
        //mongo
        public CustomerController(IMediator mediator, ICustomerService customerSQLService, ICustomerMongoService customerService, ILogger<CustomerController> logger)
        {
            this.customerService = customerService;
            this.customerSQLService = customerSQLService;
            this.mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "")
        {
            return Ok(await customerService.GetAllAsync(search));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await customerService.Create(customer);
            return Ok(customer.key);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Customer customer)
        {
            //var objectId = new ObjectId(id);
            customerService.Update(id, customer);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var getAllQuery = new DeleteCustomersCommand(customer.key);
            await mediator.Send(getAllQuery);
            //await customerService.DeleteAsync(customer.key);
            return NoContent();
        }
        //sql
       
        [HttpGet]
        [Route("/CustomerSQL/")]
        public async Task<List<CustomerGetDetails>> Get(string search="", int pageNumber=1, int pageSize=5)
        {

            //if (!string.IsNullOrWhiteSpace(searchOptional))
               // search = searchOptional;
             //List<CustomerGetDetails> source;
            _logger.LogInformation("Get Details Page");
            try
            {
                //throw new NullReferenceException();
                //throw new Exception();
                // Return List of Customer
                return await customerSQLService.FindCustomer(search);
                //source = customerService.FindCustomer(search);
                /*
                // Get's No of Rows Count   
                int count = source.Count();

                // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
                int CurrentPage = pageNumber;

                // Display TotalCount to Records to User  
                int TotalCount = count;

                // Calculating Totalpage by Dividing (No of Records / Pagesize)  
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);

                // Returns List of Customer after applying Paging   
                var items = source.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();

                // if CurrentPage is greater than 1 means it has previousPage  
                var previousPage = CurrentPage > 1 ? "Yes" : "No";

                // if TotalPages is greater than CurrentPage means it has nextPage  
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

                // Object which we are going to send in header   
                var paginationMetadata = new
                {
                    totalCount = TotalCount,
                    pageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage,
                    nextPage
                };

                // Setting Header  
                HttpContext.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
                // Returing List of Customers Collections  
                return items;
               // del*/
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "This Exception is from Get Details Page.");
                return null;
            }
        }
    }
}
