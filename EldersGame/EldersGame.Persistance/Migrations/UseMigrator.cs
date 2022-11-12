using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace EldersGame.Persistence.Migrations
{
    public static class UseMigrator
    {
        public static void UseMigrations(IServiceCollection services) 
        {
            services.AddFluentMigratorCore()
                 .ConfigureRunner(config =>
                 {
                     config.AddSqlServer()
                     .WithGlobalConnectionString("DefaultConnection")
                     .ScanIn(Assembly.GetExecutingAssembly()).For.All();
                 });
        }

        public static void UpdateDatabase(this IApplicationBuilder application)
        {
            using var scope = application.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateUp();
        }

    }
}
