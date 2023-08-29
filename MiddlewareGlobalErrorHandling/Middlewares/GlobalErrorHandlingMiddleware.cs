using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MiddlewareGlobalErrorHandling;
public class GlobalErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;
    public GlobalErrorHandlingMiddleware(ILogger<GlobalErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Server Error",
                Type = "Server Error",
                Detail = "an internal server error occurred"
            };

            string json = JsonSerializer.Serialize(problem);
            await context.Response.WriteAsync(json);
            context.Response.ContentType = "application/json";
        }
    }
}
