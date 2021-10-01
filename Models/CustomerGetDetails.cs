using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Models
{
    public class CustomerGetDetails
    {
        public long Key { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Type { get; set; }
    }
}
