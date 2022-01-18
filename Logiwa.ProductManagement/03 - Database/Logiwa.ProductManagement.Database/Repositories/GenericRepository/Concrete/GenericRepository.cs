using Logiwa.ProductManagement.Database.Repositories.GenericRepository.Abstract;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Database.Repositories.GenericRepository.Concrete
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        public GenericRepository(IUnitOfWorkFactory _unitOfWorkFactory) => this.unitOfWorkFactory = _unitOfWorkFactory;


        public async Task<bool> InsertAsync(IUnitOfWork unitOfWork, TEntity entity)
        {
            DbContext currentDbContext = unitOfWork.GetCurrentDbContext<DbContext>();
            EntityEntry<TEntity> entityEntry = await currentDbContext.Set<TEntity>().AddAsync(entity);
            var num = await currentDbContext.SaveChangesAsync();
            currentDbContext = (DbContext)null;
            return num > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(IUnitOfWork unitOfWork, TEntity entity)
        {
            DbContext currentDbContext = unitOfWork.GetCurrentDbContext<DbContext>();
            currentDbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            var num = await currentDbContext.SaveChangesAsync();
            currentDbContext = (DbContext)null;
            return num > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(IUnitOfWork unitOfWork, TEntity entity)
        {
            DbContext currentDbContext = unitOfWork.GetCurrentDbContext<DbContext>();
            currentDbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
            var num = await currentDbContext.SaveChangesAsync();
            return num > 0 ? true : false;
        }

        public async Task<TEntity> GetAsync(IUnitOfWork unitOfWork, Expression<Func<TEntity, bool>> predicate)
        {
            return await unitOfWork.GetCurrentDbContext<DbContext>().Set<TEntity>().Where<TEntity>(predicate).FirstOrDefaultAsync<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(IUnitOfWork unitOfWork, TKey Id)
        {
            return await unitOfWork.GetCurrentDbContext<DbContext>().Set<TEntity>().Where<TEntity>((Expression<Func<TEntity, bool>>)(x => x.Id.Equals((object)Id))).FirstOrDefaultAsync<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(IUnitOfWork unitOfWork)
        {
            return (IEnumerable<TEntity>)await unitOfWork.GetCurrentDbContext<DbContext>().Set<TEntity>().ToListAsync<TEntity>();
        }

        public async Task<bool> SoftDeleteAsync(IUnitOfWork unitOfWork, TEntity entity)
        {
            DbContext currentDbContext = unitOfWork.GetCurrentDbContext<DbContext>();
            ((object)entity as EntityBase<TKey>).IsDeleted = true;
            currentDbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            int num = await currentDbContext.SaveChangesAsync();
            return num > 0 ? true : false;
        }

        public IQueryable<TEntity> GetIQueryable(IUnitOfWork unitOfWork)
        {
            return (IQueryable<TEntity>)unitOfWork.GetCurrentDbContext<DbContext>().Set<TEntity>().AsQueryable();
        }
    }
}
