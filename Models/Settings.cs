using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Models
{
    public class Settings
    {
        //[BsonId]
        public int Key { get; set; }
        public string Name { get; set; }
        public string Value { get; set; } 
        public int gstValue { get { return Int32.Parse(new String(Value.Where(Char.IsDigit).ToArray())); } }
    }
}
