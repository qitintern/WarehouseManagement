using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class BinContent
	{
		public int binId { get; set; }
		public int stockId { get; set; }
		public int quantity { get; set; }
		public DateTime stockInDate { get; set; }
		public DateTime stockOutDate { get; set; }
	}
}