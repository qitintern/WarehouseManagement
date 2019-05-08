using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductGroup> ProductGroup { get; set; }
    }
}