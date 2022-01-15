using System;
using System.Reflection;
using Logiwa.ProductManagement.Entities.Category;
using Logiwa.ProductManagement.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logiwa.ProductManagement.Database.Data.MicrosoftSQLServer
{
    public class LPMMSSQLDbContext : DbContext
    {
        private IConfigurationRoot configuration;

        public LPMMSSQLDbContext()
        {
            string appSettings = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            this.configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{appSettings}.json")
                .Build(); 
        }

        #region DbSets
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        #endregion

        #region Life Cycle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSqlDefaultConnection"));

        }
        #endregion

    }

}
