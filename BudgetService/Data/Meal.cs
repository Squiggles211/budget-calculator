using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Web;

using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace BudgetService.Data
{
	[Route("/meals", "GET")]
	[Route("/meals/{account}", "GET")]
	public class Meal
	{
		public string account { get; set; }

		public string name { get; set; }

		public Meal() { }
	}
}
