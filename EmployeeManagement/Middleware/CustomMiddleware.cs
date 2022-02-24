using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware :IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public CustomMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("My Custom Logger");
            _logger.LogInformation("My Custom Middleware Started");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("My Custom Middleware Executed");
            await _next.Invoke(httpContext);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //await context.Response.WriteAsync("Incoming Request \n");
            //await next(context);
            //await context.Response.WriteAsync(" Outgoing Response \n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
