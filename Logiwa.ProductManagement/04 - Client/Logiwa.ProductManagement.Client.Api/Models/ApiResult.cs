using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Client.Api.Models
{
    public interface IApiResult
    { 
        string Message { get; }
        bool Succeeded { get; }
        object Data { get; }
    }

    public class ApiResult : IApiResult
    {
        protected ApiResult() { }

        public string Message { get; protected set; }

        public bool Succeeded { get; protected set; }
        public object Data { get; protected set; }

        public static IApiResult Fail(string message) => new ApiResult { Succeeded = false, Message = message };
        public static IApiResult Success(object data) => new ApiResult { Succeeded = true, Data = data };
        public static IApiResult Success(object data, string message) => new ApiResult { Succeeded = true, Data = data, Message = message };
    }
}
