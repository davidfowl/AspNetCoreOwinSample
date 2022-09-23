public class AspNetCoreMiddleware
{
    private readonly RequestDelegate _next;

    public AspNetCoreMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        httpContext.Request.Headers.Append("Framework", "ASP.NET Core");
        return _next(httpContext);
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseAspNetCoreMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AspNetCoreMiddleware>();
    }
}
