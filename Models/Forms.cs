using MongoDB.Bson;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace AllMart_WebApi.Models
{
    public class Forms
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public long form_id { get; set; }
        public int tenant_id { get; set; }
        public Object data { get; set; }
        public DateTime update_dt { get; set; }
        public string version { get; set; }
        public Boolean status { get; set; }
    }
}
