using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using DbUp;
using DbUp.Engine;
using System.Reflection;
using System.Diagnostics;

namespace CustomerManagement.Data.Sql
{
    class Program
    {
        private const string dbContext = "customermanagementdbcontext";
        static int Main(string[] args)
        {
            Console.WriteLine("Performing database upgrade!");

            var connectionString = GetConnectionString() ?? "Data Source=.;Initial Catalog=customermanagement;Integrated Security=True";

            var result = PerformUpgrade(connectionString);
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(result.Error);
                Console.ResetColor();

                if (Debugger.IsAttached) Debugger.Break();
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Success!");
            Console.ResetColor();
            return 0;
        }

        private static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.AppSettings[dbContext];
            return connectionString;
        }

        public static DatabaseUpgradeResult PerformUpgrade(string connectionString)
        {
            var upgrader = DeployChanges.To.SqlDatabase(connectionString).WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()).WithExecutionTimeout(TimeSpan.FromMinutes(6)).LogToConsole().Build();

            return upgrader.PerformUpgrade();
        }
    }
}
