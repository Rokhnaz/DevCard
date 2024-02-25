namespace DotNetCoreFundamental2
{
    public class CustomLogger
    {
        private readonly RequestDelegate _next;

        public CustomLogger(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var q = context.Request.Query["Name"];
            return _next(context);
            
        }
    }

    public static class CustomLoggerExt
    {
        public static IApplicationBuilder UseCustomLoggerExtension(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomLogger>();
        }
    }



}
