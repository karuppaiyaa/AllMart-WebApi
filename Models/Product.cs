using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace AllMart_WebApi.Models
{
    public class Product
    {
        //[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public double price { get; set; }
        public string measure { get; set; }
        public string tags { get; set; }
    }
}
