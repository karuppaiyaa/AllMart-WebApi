using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMart_WebApi.Models
{
    public class CustomerData
    {
        //[BsonId]
        public Guid Id { get; set; }
        public long key { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string place { get; set; }
        public string pincode { get; set; }
        public string email { get; set; }
        public long mobileNumber { get; set; }
        public short customerType { get; set; }
    }
}
