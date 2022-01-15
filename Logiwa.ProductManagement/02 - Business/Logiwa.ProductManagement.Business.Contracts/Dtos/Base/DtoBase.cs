using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Business.Contracts.Dtos.Base
{
    public class DtoBase<TKey>
    {
        public TKey Id { get; protected set; }
        public DateTime CreatedUtc { get; set; }
        public bool IsDeleted { get; set; }

        public DtoBase()
        {
            CreatedUtc = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}
