using Microsoft.AspNetCore.Authentication;

namespace WebApplication5.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseStatistics(this IApplicationBuilder app)
        {
            return app.UseMiddleware<StatisticsMiddleware>();
        }
    }
}
