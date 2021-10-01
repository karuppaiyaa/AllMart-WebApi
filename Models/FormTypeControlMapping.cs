using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using Dapper.Contrib.Extensions;

namespace AllMart_WebApi.Models
{
    public class FormTypeControlMapping
    {

        public FormType FormType { get; set; }
        public FormControl[] FormControl { get; set; }
        public Boolean active { get; set; }

     /*   public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }*/
    }
}
