using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class Bin
	{
		public int ID { get; set; }
		public string Description { get; set; }
		public int WarehouseID { get; set; }
	}
}