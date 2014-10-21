using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Web;

using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;
using ServiceStack.OrmLite;

namespace BudgetService.Data
{
	//Force only being able to get a month by month view (impossible to get all for an account or all for a year?)
	[Route("/plans/{account}/{year}/{month}", "GET")]
	[Route("/plans/{account}/{year}/{month}/{day}", "GET")]
	public class DayPlan
	{
		public string account { get; set; }

		public int year { get; set; }

		public int month { get; set; }

		public int day { get; set; }

		//Need to store a list of meals and expenses for the day
		//public List<string> meals { get; set; }
		//public List<Expense> expenses { get; set; }

		public DayPlan ()
		{
		}
	}
}

