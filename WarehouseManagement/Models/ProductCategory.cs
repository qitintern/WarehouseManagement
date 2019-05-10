using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class ProductCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public virtual ICollection<ProductGroup> productGroup { get; set; }
    }
}