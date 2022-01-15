using Logiwa.ProductManagement.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Entities.Category
{
    public class Category : EntityBase<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Product.Product> Products { get; set; }
    }
}
