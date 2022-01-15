using Logiwa.ProductManagement.Database.Data.Factory;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Logiwa.ProductManagement.Database.UnitOfWork.Concrete
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDbContextFactory dbContextFactory;
        private readonly IConfiguration configuration;
        private string databaseProvider;

        public UnitOfWorkFactory(
          IHttpContextAccessor httpContextAccessor,
          IDbContextFactory dbContextFactory,
          IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContextFactory = dbContextFactory;
            this.configuration = configuration;

            this.databaseProvider = configuration.GetValue<string>("DatabaseProvider");
        }

        public IUnitOfWork Create() => (IUnitOfWork)new UnitOfWork(this.httpContextAccessor, this.dbContextFactory.GetDbContextModel(this.databaseProvider), false);

        public IUnitOfWork CreateWithStack() => (IUnitOfWork)new UnitOfWork(this.httpContextAccessor, this.dbContextFactory.GetDbContextModel(this.databaseProvider), true);

        public TDbContext GetDbContextFromStack<TDbContext>() => new UnitOfWork(this.httpContextAccessor).GetDbContextFromStack<TDbContext>(false);
    }
}
