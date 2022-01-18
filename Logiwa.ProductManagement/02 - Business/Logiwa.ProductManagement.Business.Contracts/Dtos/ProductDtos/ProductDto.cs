
using Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos;
using Logiwa.ProductManagement.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos
{
    public class ProductDto : DtoBase<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
