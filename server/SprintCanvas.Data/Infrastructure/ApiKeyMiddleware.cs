namespace SprintCanvas.Data.Infrastructure;

public class ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private const string ApiKeyHeader = "X-Api-Key";

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var receivedKey)
            || receivedKey != configuration["ApiKey"])
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await next(context);
    }
}
