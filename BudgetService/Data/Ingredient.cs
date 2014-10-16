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
	[Route("/ingredients", "GET")] //get all ingredients
	[Route("/ingredients/{meal}", "GET")] //get all ingredients for a meal
	[Route("/ingredients/{uid}", "GET")] //get an ingredient by id
	[Route("/ingredients/{account}", "GET")] //get all ingredients for an account
	public class Ingredient
	{
		[DataMember]
		public string account { get; set; }

		[DataMember]
		public string name { get; set; }

		//cost as a float
		[DataMember]
		public float cost { get; set; }

		public Ingredient ()
		{
		}
	}
}

