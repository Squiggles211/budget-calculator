
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
	[Route("/meals", "GET")]
	[Route("/meals/{uid}")]
	class Meal : IReturn<MealResponse>
	{
		[DataMember]
		public string uid { get; set; }

		[DataMember]
		public string desc { get; set; }

		public Meal() { }
	}

	[DataContract]
	class MealResponse
	{
	}
}
