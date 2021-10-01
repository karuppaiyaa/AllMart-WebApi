using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Models
{
    public class Items
    {
        public string productId { get; set; }
        public int quantity { get; set; }
        public double amount { get; set; }
    }
}
