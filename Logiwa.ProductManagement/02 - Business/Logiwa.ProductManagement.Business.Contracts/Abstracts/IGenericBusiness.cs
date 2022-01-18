using Logiwa.ProductManagement.Core.Base;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Logiwa.ProductManagement.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.Abstracts
{
    public interface IGenericBusiness<TEntity,TDto, TKey>
        where TEntity: EntityBase<TKey>, new()
        where TDto : DtoBase<TKey>, new()
    {
        Task<TDto> GetByIdAsync(IUnitOfWork unitOfWork, TKey Id);
        Task<IEnumerable<TDto>> GetListAsync(IUnitOfWork unitOfWork);
        Task<bool> InsertAsync(IUnitOfWork unitOfWork, TDto dto);
        Task<bool> UpdateAsync(IUnitOfWork unitOfWork, TKey id, TDto dto);
        Task<bool> DeleteById(IUnitOfWork unitOfWork, TKey id);
    }
}
