using Logiwa.ProductManagement.Business.Category;
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Business.Contracts.Validations;
using Logiwa.ProductManagement.Client.Api.Models;
using Logiwa.ProductManagement.Database.UnitOfWork.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Client.Api.Controllers
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> logger;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly ICategoryBusiness categoryBusiness;

        public CategoryController(ILogger<CategoryController> _logger, IUnitOfWorkFactory _unitOfWorkFactory, ICategoryBusiness _categoryBusiness)
        {
            logger = _logger;
            unitOfWorkFactory = _unitOfWorkFactory;
            categoryBusiness = _categoryBusiness;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<JsonResult> Get()
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var data = await categoryBusiness.GetListAsync(uow);
                return new JsonResult(ApiResult.Success(data));
            }
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<JsonResult> Get(int id)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var data = await categoryBusiness.GetByIdAsync(uow, id);
                return new JsonResult(data == null ? ApiResult.Fail("No data found") : ApiResult.Success(data));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] CategoryDto data)
        {
            var categoryValidator = new CategoryValidation();
            var validationResult = categoryValidator.Validate(data);

            if (validationResult.Failed) return new JsonResult(ApiResult.Fail(validationResult.Message));

            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await categoryBusiness.InsertAsync(uow, data);
                return new JsonResult(result ? ApiResult.Success("Success") : ApiResult.Fail("Error"));
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<JsonResult> Update(int id, [FromBody] CategoryDto data)
        {
            var categoryValidator = new CategoryValidation();
            var validationResult = categoryValidator.Validate(data);

            if (validationResult.Failed) return new JsonResult(ApiResult.Fail(validationResult.Message));

            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await categoryBusiness.UpdateAsync(uow, id, data);
                return new JsonResult(result ? ApiResult.Success("Success") : ApiResult.Fail("Error"));
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await categoryBusiness.SoftDeleteAsync(uow, id);
                return new JsonResult(result ? ApiResult.Success("Success") : ApiResult.Fail("Error"));
            }
        }
    }
}
