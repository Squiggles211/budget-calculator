using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using ServiceStack.ServiceInterface;
using Mono.Data.Sqlite;

namespace BudgetService.Services
{
	using Data;

	public class MealService : Service
	{
		public MealService ()
		{
		}

		public object Get(Meal meal)
		{
			var response = new List<Meal>();

			var query = Db.CreateCommand();

			query.CommandText = "Select ACCT_NAME, MEAL_NAME from meals ";
			int parameters = 0;

			//should not retrieve meals for an account unless authenticated!
			//Also, should not retrieve anything if account is not given
			if(meal.account != null && meal.account.Length > 0)
			{
				try
				{
					Console.WriteLine("Account not null!");

					query.CommandText += "where ACCT_NAME = @acct";

					var param = query.CreateParameter();
					param.ParameterName = "@acct";
					param.Value = meal.account;

					//add parameter
					query.Parameters.Add(param);

					parameters++;

					if(meal.name != null && meal.name.Length > 0)
					{
						query.CommandText += " and MEAL_NAME = @meal";

						var param2 = query.CreateParameter();
						param2.ParameterName = "@meal";
						param2.Value = meal.name;

						//add second parameter
						query.Parameters.Add(param2);

						parameters++;
					}

					query.Prepare();
					var reader = query.ExecuteReader();

					while(reader.Read())
					{
						response.Add(new Meal() { 
							account = reader.GetString(0),
							name = reader.GetString(1)
						});
					}
				}
				catch(Exception e)
				{
					Console.WriteLine(e.StackTrace);
				}
			}
			else
			{
				Console.WriteLine("Account was null :(");
			}

			Console.WriteLine("After Processing.. ");

			return response;
		}

		public object Get(Ingredient ingredient)
		{
			return new List<Ingredient>();
		}

		public object Get(Recipe recipe)
		{
			return new List<Recipe>();
		}
	}
}

