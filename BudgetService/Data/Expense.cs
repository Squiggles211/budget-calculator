using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Web;

using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;

namespace BudgetService.Data
{
	//Allow a user to retrieve their expenses month by month, or retrieve all

	[Route("/expenses/{account}", "GET")]
	[Route("/expenses/{account}/{year}/{month}", "GET")]
	public class Expense
	{
		public string account { get; set; }

		//if expense is recurring, year and month can be anything as they are ignored (force db constraint?)
		public bool recurring { get; set; }

		public int year { get; set; }

		public int month { get; set; }

		public Expense ()
		{
		}
	}
}

