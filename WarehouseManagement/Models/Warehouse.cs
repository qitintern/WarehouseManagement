using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class Warehouse
	{
		public int id { get; set; }
		public string name { get; set; }
		public string location { get; set; }
		public int companyId { get; set; }

	}
}