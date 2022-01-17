using Logiwa.ProductManagement.Business.Contracts.Abstracts;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Database.Repositories.CategoryRepository;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Category
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryBusiness(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<bool> DeleteById(IUnitOfWork unitOfWork, int id)
        {
            var entity = await categoryRepository.GetByIdAsync(unitOfWork, id);
            await categoryRepository.DeleteAsync(unitOfWork, entity);
            return true;
        }

        public async Task<CategoryDto> GetByIdAsync(IUnitOfWork unitOfWork, int id)
        {
            var data = await categoryRepository.GetByIdAsync(unitOfWork, id);
            return AutoMapper.Mapper.Map<CategoryDto>(data);
        }

        public async Task<IEnumerable<CategoryDto>> GetListAsync(IUnitOfWork unitOfWork)
        {
            var data = await categoryRepository.GetListAsync(unitOfWork);
            return AutoMapper.Mapper.Map<List<CategoryDto>>(data);
        }

        public async Task InsertAsync(IUnitOfWork unitOfWork, CategoryDto dto)
        {
            var entity = AutoMapper.Mapper.Map<Entities.Category.Category>(dto);
            await categoryRepository.InsertAsync(unitOfWork, entity);
        }

        public async Task SoftDeleteAsync(IUnitOfWork unitOfWork, CategoryDto dto)
        {
            var entity = AutoMapper.Mapper.Map<Entities.Category.Category>(dto);
            entity.IsDeleted = true;
            await categoryRepository.UpdateAsync(unitOfWork, entity);
        }

        public async Task UpdateAsync(IUnitOfWork unitOfWork, CategoryDto dto)
        {
            var data = await categoryRepository.GetByIdAsync(unitOfWork, dto.Id);
            var entity = AutoMapper.Mapper.Map<CategoryDto, Entities.Category.Category>(dto, data);
            await categoryRepository.UpdateAsync(unitOfWork, entity);
        }
    }
}
