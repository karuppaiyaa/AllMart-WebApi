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
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AllMart_WebApi.Controllers
{
    [Route("Bills")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillsService billsService = new BillsService();

        [HttpGet("{Id}")]
        public async Task<Bills> Get(string Id)
        {
            return await billsService.GetById(Id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Bills bills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await billsService.Create(bills);
            return Ok(bills.Id);
        }
    }
}
