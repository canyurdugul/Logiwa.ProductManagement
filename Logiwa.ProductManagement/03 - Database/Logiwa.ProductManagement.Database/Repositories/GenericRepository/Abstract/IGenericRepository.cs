using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Database.Repositories.GenericRepository.Abstract
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        Task<TEntity> GetByIdAsync(IUnitOfWork unitOfWork, TKey Id);
        Task<TEntity> GetAsync(IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync(IUnitOfWork unitOfWork);
        Task<bool> InsertAsync(IUnitOfWork unitOfWork, TEntity entity);
        Task<bool> UpdateAsync(IUnitOfWork unitOfWork, TEntity entity);
        Task<bool> DeleteAsync(IUnitOfWork unitOfWork, TEntity entity);
        Task<bool> SoftDeleteAsync(IUnitOfWork unitOfWork, TEntity entity);
    }
}
