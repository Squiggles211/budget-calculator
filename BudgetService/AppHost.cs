using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Mono.Unix;
using Mono.Unix.Native;

using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceInterface.Cors;
using ServiceStack.Text;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;

namespace BudgetService
{
	using Funq;
	using Data;

	public class AppHost : AppHostHttpListenerBase
	{
		public bool isConnectedToDB = false;

		public AppHost () : base("Budget Service", typeof(AppHost).Assembly)
		{
		}

		public override void Configure(Container container)
		{
			//We want camel case.
			JsConfig.EmitCamelCaseNames = true;

			//Attempt a DB connection
			try
			{
				container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory("./budgetplanning.db", SqliteOrmLiteDialectProvider.Instance));

				//using (var connection = container.Resolve<IDbConnectionFactory>().OpenDbConnection())
				//{
					//connection.CreateTableIfNotExists<Meal>();
					//connection.CreateTableIfNotExists<Ingredient>();
					//connection.CreateTableIfNotExists<Recipe>();
				//}

				this.isConnectedToDB = true;
			}
			catch (Exception e)
			{
				e.PrintDump ();
				Console.WriteLine ("Fatal: Cannot make connection to database, service will not be initialized!");
			}

			//Set custom request filter
			this.RequestFilters.Clear ();
			this.RequestFilters.Add((req, res, requestDto) =>
			{
				Console.WriteLine(req.AbsoluteUri);
			});

			Plugins.Add (new CorsFeature ());

			SetConfig (new EndpointHostConfig
			{
				DebugMode = true,
			});
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//initialize app host
			var appHost = new AppHost ();

			appHost.Init();

			//If the app has connected to the database, then we can start the service
			if (appHost.isConnectedToDB)
			{
				appHost.Start ("http://localhost:7001/");

				UnixSignal[] signals = new UnixSignal[]
				{
					new UnixSignal(Signum.SIGINT),
					new UnixSignal(Signum.SIGTERM),
				};

				//Wait for a unix signal
				for (bool exit = false; !exit;)
				{
					int id = UnixSignal.WaitAny (signals);

					if (id >= 0 && id < signals.Length)
					{
						if (signals [id].IsSet)
							exit = true;
					}
				}
			}
		}
	}
}



