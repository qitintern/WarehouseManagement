using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public string street { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }
}