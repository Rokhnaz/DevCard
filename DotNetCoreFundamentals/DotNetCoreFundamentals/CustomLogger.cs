namespace DotNetCoreFundamentals
{
    public class CustomLogger
    {
        private RequestDelegate _next;

        public CustomLogger(RequestDelegate next)
        {
            _next = next;

        }

        public Task Invoke(HttpContext context)
        {
            var cnt = context.Request.Query["Name"];
            return _next(context);
        }
    }

    public static class CustomLoggerExtension
    {
        public static IApplicationBuilder UseExtensionBuilder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomLogger>();
        }
    }
}
