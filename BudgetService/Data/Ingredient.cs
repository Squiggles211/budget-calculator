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
	[Route("/ingredients/{account}/{meal}", "GET")] //get a specific ingredient for a meal
	public class Ingredient
	{
		//account of the ingredient - PK/FK
		public string account { get; set; }

		//name of the ingredient - PK
		public string name { get; set; }

		//cost as a float
		public float cost { get; set; }

		//used to retrieve all ingredients for a specific meal if user desires
		public string meal { get; set; }

		public Ingredient ()
		{
		}
	}
}

