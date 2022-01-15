using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Core.Validation.Objects
{
    public interface IResult
    {
        bool Failed { get; }
        string Message { get; }
        bool Succeeded { get; }
    }
}
