using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public class CustomLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        // The RequestDelegate is essential for calling the next middleware
        public CustomLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // 1. Logic BEFORE the rest of the pipeline
            var startTime = DateTime.Now;

            // 2. Call the next middleware in the pipeline
            await _next(context);

            // 3. Logic AFTER the rest of the pipeline
            var duration = DateTime.Now - startTime;
            Console.WriteLine($"Request for {context.Request.Path} completed in {duration.TotalMilliseconds}ms.");
        }
    }
}
