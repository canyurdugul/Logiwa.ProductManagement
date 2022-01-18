using Logiwa.ProductManagement.Database.Data.MicrosoftSQLServer;

namespace Logiwa.ProductManagement.Database.Data.Factory
{
    public interface IDbContextFactory
    {
        DbContextModel GetDbContextModel();
    }

    public class DbContextFactory : IDbContextFactory
    {
        public DbContextModel GetDbContextModel()
        {
            return new DbContextModel { DbContext = new LPMMSSQLDbContext() };
        }

    }
}
