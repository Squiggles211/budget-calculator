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
	[Route("/expenses", "GET")]
	[Route("/expenses/{account}", "GET")]
	public class Expense
	{
		public Expense ()
		{
		}
	}
}

