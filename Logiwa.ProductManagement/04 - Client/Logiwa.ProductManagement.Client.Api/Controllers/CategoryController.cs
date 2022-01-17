using Logiwa.ProductManagement.Business.Category;
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
        public async Task<JsonResult> GetAll()
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var data = await categoryBusiness.GetListAsync(uow);
                return new JsonResult(ApiResult.Success(data));
            }
        }
    }
}
