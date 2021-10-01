using AllMart_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AllMart_WebApi.Controllers
{
    [Route("Forms")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IMongoCollection<Forms> _customer;

        public FormsController()
        {
            var client = new MongoClient("mongodb+srv://Squad1:Karupp7548@cluster-dynamic-forms.c26wp.mongodb.net?retryWrites=true&w=majority");
            var database = client.GetDatabase("Dynamic_Forms");
            _customer = database.GetCollection<Forms>("Form");
        }

        [HttpGet]
        public async Task<IEnumerable<Forms>> GetAll()
        {
                return await _customer.Find(c => true).ToListAsync();
        }
  
    }
}
