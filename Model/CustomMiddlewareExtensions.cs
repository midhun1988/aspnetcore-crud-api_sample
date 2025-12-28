using Microsoft.AspNetCore.Builder;

namespace CRUDAPI.Models
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLoggerMiddleware>();
        }
    }
}
