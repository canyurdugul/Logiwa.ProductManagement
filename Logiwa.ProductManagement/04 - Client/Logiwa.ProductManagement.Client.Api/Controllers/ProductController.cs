using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using Logiwa.ProductManagement.Business.Product;
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
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IProductBusiness productBusiness;

        public ProductController(ILogger<ProductController> logger, IUnitOfWorkFactory _unitOfWorkFactory, IProductBusiness _productBusiness)
        {
            logger = _logger;
            unitOfWorkFactory = _unitOfWorkFactory;
            productBusiness = _productBusiness;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<JsonResult> Get()
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await productBusiness.GetListAsync(uow);
                return new JsonResult(ApiResult.Success(result));
            }
        }

        [HttpPost]
        [Route("search")]
        public  JsonResult Search([FromBody] SearchProductDto searchData)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = productBusiness.SearchProduct(uow, searchData);
                return new JsonResult(ApiResult.Success(result));
            }
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<JsonResult> Get(int id)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await productBusiness.GetByIdAsync(uow, id);
                return new JsonResult(result == null ? ApiResult.Fail("No data found") : ApiResult.Success(result));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<JsonResult> Create([FromBody] ProductDto data)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await productBusiness.InsertAsync(uow, data);
                return new JsonResult(result ? ApiResult.Success("Success") : ApiResult.Fail("Error"));
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<JsonResult> Update(int id, [FromBody] ProductDto data)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await productBusiness.UpdateAsync(uow, id, data);
                return new JsonResult(result ? ApiResult.Success("Success") : ApiResult.Fail("Error"));
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            using (var uow = unitOfWorkFactory.Create())
            {
                var result = await productBusiness.DeleteById(uow, id);
                return new JsonResult(result ? ApiResult.Success("Success") : ApiResult.Fail("Error"));
            }
        }
    }
}
