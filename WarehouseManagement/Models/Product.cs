using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int GroupID { get; set; }

        public virtual ProductGroup Group { get; set; }
    }
}