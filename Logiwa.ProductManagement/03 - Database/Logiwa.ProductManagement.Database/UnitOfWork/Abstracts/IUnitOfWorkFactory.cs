namespace Logiwa.ProductManagement.Database.UnitOfWork.Abstracts
{
    public interface IUnitOfWorkFactory
    {
        TDbContext GetDbContextFromStack<TDbContext>();
        IUnitOfWork Create();
        IUnitOfWork CreateWithStack();
    }
}
