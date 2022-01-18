using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Logiwa.ProductManagement.Client.Api.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        static readonly Serilog.ILogger Log = Serilog.Log.ForContext<ExceptionHandler>();
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            Log.Error($"{now.ToString("HH:mm:ss")} : {ex}");
            return httpContext.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new ErrorResultModel()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message
            }));
        }
    }
}
