using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenAPI.Infra.Contexts
{
    /*
    public class SQLServerContextFactory : IDesignTimeDbContextFactory<SQLServerContext>
    {
        /// <summary>
        /// Retrieves the connection string from the appsettings.json file in run-time and connects the SQLServerContext class to a Microsoft SQL Server database.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>An instance of the SQLServerContext class.</returns>
        public SQLServerContext CreateDbContext(string[] args)
        {
            

            #region Setting the DB connection

            var options = new DbContextOptionsBuilder<SQLServerContext>();
            options.UseSqlServer(GetConnectionString());

            #endregion

            return new SQLServerContext(options.Options);
        }

        public static string GetConnectionString()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            #region Retrieving the connection string from the appsettings.json file

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(path);

            return builder.Build().GetConnectionString("ModelAPI");

            #endregion
        }
    }
    */
}
