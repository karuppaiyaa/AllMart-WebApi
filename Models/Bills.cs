using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace AllMart_WebApi.Models
{
    public class Bills
    {
        //[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public double billNo { get; set; }
        public string customerId { get; set; }
        public string billDate { get; set; }
        public Items[] items { get; set; }
        public double amount { get; set; }
        public int gstPercent { get; set; }
        public double total { get; set; }
    }
}
