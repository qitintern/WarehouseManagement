using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagement.Models
{
	public class User
	{
		public int ID { get; set; }
		public string Fname { get; set; }
		public string Lname { get; set; }
		public string UserType { get; set; }
		public DateTime UserJoinDate { get; set; }
		public DateTime UserQuitDate { get; set; }
	}
}