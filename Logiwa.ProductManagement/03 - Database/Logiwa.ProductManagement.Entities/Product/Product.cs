using Logiwa.ProductManagement.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Entities.Product
{
    public class Product : EntityBase<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category.Category Category { get; set; }
    }
}
