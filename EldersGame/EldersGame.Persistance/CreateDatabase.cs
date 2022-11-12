using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EldersGame.Persistence
{
    public static class CreateDatabase
    {
        public static void EnsureDatabase(IConfiguration configuration)
        {
            var masterConnectionString = configuration.GetConnectionString("MasterConnection");
            var eldersGameConnectionString = new SqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"));

            var name = eldersGameConnectionString.InitialCatalog;

            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            using var connection = new SqlConnection(masterConnectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}
