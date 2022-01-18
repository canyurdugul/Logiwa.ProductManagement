using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.Dtos.ProductDtos
{
    public class SearchProductDto
    {
        public string Keyword { get; set; }
        public int? MinimumStockQuantity { get; set; }
        public int? MaximumStockQuantity { get; set; }
    }
}
