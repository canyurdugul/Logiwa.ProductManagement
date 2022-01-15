using Logiwa.ProductManagement.Business.Contracts.Dtos.Base;
using Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.Dtos.CategoryDtos
{
    public class CategoryDto : DtoBase<int>
    {
        public string Name { get; set; }
        public int MinimumStockQuantity { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
