using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    // Download Microsoft.Extensions.Configuration.FileExtensions && Microsoft.Extensions.Configuration.Json
    public static class ConfigureConnectionString
    {
        public static string ConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();

            // Birden fazla yol vardir.

            string connectionString = configuration.GetConnectionString("MsSqlConnection");
            //string connectionString2 = (string)configuration.GetValue(typeof(string), "ConnectionStrings:MsSqlConnection");
            //string connectionString3 = configuration.GetValue<string>("ConnectionStrings:MsSqlConnection");
            //string connectionString4 = configuration["ConnectionStrings:MsSqlConnection"];

            return connectionString;
        }
    }
}