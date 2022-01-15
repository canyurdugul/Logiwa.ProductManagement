using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Entities.Base
{
    public class EntityBase<TKey>
    {
        public TKey Id { get; protected set; }
        public DateTime CreatedUtc { get; set; }
        public bool IsDeleted { get; set; }

        public EntityBase()
        {
            CreatedUtc = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}
