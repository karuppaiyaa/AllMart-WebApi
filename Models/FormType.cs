using MongoDB.Bson;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using Dapper.Contrib.Extensions;

namespace AllMart_WebApi.Models
{
    public class FormType
    {

        public int formtype_id { get; set; }
        public string formtype_name { get; set; }

    /*    public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }*/
    }
}
