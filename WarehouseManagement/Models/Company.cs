using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class Company
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Unit { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}