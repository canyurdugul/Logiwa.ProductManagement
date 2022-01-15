using Logiwa.ProductManagement.Database.Data.MicrosoftSQLServer;
using Logiwa.ProductManagement.Database.Data.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Database.Data.Factory
{
    public interface IDbContextFactory
    {
        DbContextModel GetDbContextModel(string databaseProvider);
    }

    public class DbContextFactory : IDbContextFactory
    {
        public DbContextModel GetDbContextModel(string databaseProvider)
        {
            if (databaseProvider == "MSSQL") { return new DbContextModel { DbContext = new LPMMSSQLDbContext() }; }
            else if (databaseProvider == "POSTGRESQL") { return new DbContextModel { DbContext = new LPMPostgreSQLDbContext() }; }
            else throw new Exception("No provider found");
        }
    }
}
