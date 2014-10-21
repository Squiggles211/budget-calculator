using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using ServiceStack.ServiceInterface;
using Mono.Data.Sqlite;

namespace BudgetService.Services
{
	using Data;

	public class BudgetService : Service
	{
		public BudgetService ()
		{
		}

		public object Get(Expense expense)
		{
			return new List<Expense>();
		}

		public object Get (DayPlan plan)
		{
			return new List<DayPlan>();
		}
	}
}

