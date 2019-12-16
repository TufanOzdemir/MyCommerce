using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace MyCommerce.Basket.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExceptionHandlerMiddleware(RequestDelegate next, IHostingEnvironment hostingEnvironment)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AuthenticationException ex)
            {
                var exModel = new GeneralError { Message = "Not Authorized", Status = HttpStatusCode.Unauthorized };
                await ContextDecorator(context, exModel);
            }
            catch (Exception ex)
            {
                //Log at
                var exModel = new GeneralError { Message = _hostingEnvironment.IsDevelopment() ? ex.ToString() : "An error occurred" , Status = HttpStatusCode.InternalServerError };
                await ContextDecorator(context, exModel);
            }
        }

        private async Task ContextDecorator(HttpContext context, GeneralError error)
        {
            context.Response.Clear();
            context.Response.ContentType = "json";
            context.Response.StatusCode = error.Status.GetHashCode();
            await context.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }
    }

    public class GeneralError
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
    }

    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
