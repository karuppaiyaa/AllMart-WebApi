using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using Dapper.Contrib.Extensions;

namespace AllMart_WebApi.Models
{
    public class Customer
    {
        //[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        public int key { get; set; }
        public double version { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string place { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string customerType { get; set; }
        [Computed]
        [Write(false)]
        public string name { get { return firstName + " " + lastName; } }
    }
}
