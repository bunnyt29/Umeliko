namespace Umeliko.Web.Middleware;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class InnerExceptionHandlerMiddleware(
    RequestDelegate next,
    ILogger<InnerExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            LogExceptionDetails(ex);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occurred.");
        }
    }

    private void LogExceptionDetails(Exception ex)
    {
        // Log the complete exception details including inner exception
        logger.LogError(ex, "An unhandled exception occurred.");
    }
}

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseInnerExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<InnerExceptionHandlerMiddleware>();
    }
}
