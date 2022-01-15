using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logiwa.ProductManagement.Database.Data
{
    public class LogiwaProductManagementDbContext : DbContext
    {
        public LogiwaProductManagementDbContext()
        {

        }

        #region Life Cycle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string appSettings = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            appSettings = appSettings ?? "Development";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{appSettings}.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
        #endregion
    }
}
