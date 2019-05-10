using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class User
	{
		public int id { get; set; }
		public string fname { get; set; }
		public string lname { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string userType { get; set; }
		public DateTime userJoinDate { get; set; }
		public DateTime userQuitDate { get; set; }
	}
}