using System;
using System.Data;

namespace Logiwa.ProductManagement.Database.UnitOfWork.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        TDbContext GetCurrentDbContext<TDbContext>();
        void Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
    }
}
