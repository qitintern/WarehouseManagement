using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class Bin
	{
		public int id { get; set; }
		public string description { get; set; }
		public int warehouseId { get; set; }
	}
}