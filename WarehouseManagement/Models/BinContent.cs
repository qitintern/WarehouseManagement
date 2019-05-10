using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class BinContent
	{
		public int BinID { get; set; }
		public int StockID { get; set; }
		public int Quantity { get; set; }
		public DateTime StockInDate { get; set; }
		public DateTime StockOutDate { get; set; }
	}
}