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
	[Route("/recipes")]
	[Route("/recipes/{meal}")]
	public class Recipe
	{
		[DataMember]
		public string uid { get; set; }

		[DataMember]
		public string account { get; set; }

		[DataMember]
		public string meal { get; set; }

		[DataMember]
		public string ingredient { get; set; }

		public Recipe ()
		{
		}
	}
}

