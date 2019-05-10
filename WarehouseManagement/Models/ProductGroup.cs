using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class ProductGroup
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description{ get; set; }
        public int productCategoryId { get; set; }

        public virtual ProductCategory productCategory { get; set; }

    }
}