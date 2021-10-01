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
    [Route("Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService = new ProductService();
        private readonly ISettingsService settingsService = new SettingsService();
        
        [HttpGet]
        public async Task<IActionResult> GetAllSearch(string search = "")
        {
            return Ok(await productService.GetAllSearchAsync(search));
        }
        [HttpGet("{Id}")]
        public async Task<Product> Get(string Id)
        {
            return await productService.GetById(Id);
        }
        /*
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAllAsync());
        }*/
        [Route("Settings")]
        [HttpGet]
        public async Task<Settings> Get()
        {
            return await settingsService.Get();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await productService.Create(product);
            return Ok(product.name);
        }
    }
}
