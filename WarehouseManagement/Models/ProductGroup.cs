using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
    public class ProductGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryID { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

    }
}