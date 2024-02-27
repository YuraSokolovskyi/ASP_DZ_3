namespace WebApplication5.Middleware
{
    public class StatisticsMiddleware
    {
        private readonly RequestDelegate _next;
        private int Opera;
        private int Chrome;
        private int Firefox;
        private int Other;

        public StatisticsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string userAgent = context.Request.Headers["User-Agent"].ToString().ToLower();

            if (!context.Request.Path.Value.Contains("favicon.ico"))
            {
                if (userAgent.Contains("opera")) Opera++;
                else if (userAgent.Contains("chrome")) Chrome++;
                else if (userAgent.Contains("firefox")) Firefox++;
                else Other++;
            }

            await _next(context);

            await context.Response.WriteAsync($"<p>Visited to site</p>" +
                $"<p>Opera - {Opera}</p>" +
                $"<p>Chrome - {Chrome}</p>" +
                $"<p>Firefox - {Firefox}</p>" +
                $"<p>Other - {Other}</p>");
        }
    }
}
