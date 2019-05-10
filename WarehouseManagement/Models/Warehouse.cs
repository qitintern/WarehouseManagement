using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class Warehouse
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public int CompanyID { get; set; }

	}
}