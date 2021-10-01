using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Dapper.Contrib.Extensions;

namespace AllMart_WebApi.Models
{
    public class FormControl
    {

        public int formcontrol_id { get; set; }
        public string formcontrol_name { get; set; }
        public string version { get; set; }
        /*  public override string ToString()
          {
              return JsonConvert.SerializeObject(this, Formatting.Indented);
          }*/

        //[BsonRepresentation(BsonType.Document)]
        //public FormTypeControlMapping data { get; set; }

    }
}
