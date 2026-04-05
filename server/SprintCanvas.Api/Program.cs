using MediatR;
using SprintCanvas.Api.Common.Middleware;
using SprintCanvas.Api.Features.Health;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddMediatR(config => 
    config.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});

// Configure logging
builder.Services.AddLogging(config =>
{
    config.ClearProviders();
    config.AddConsole();
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseMiddleware<LoggingMiddleware>();
app.UseCors("AllowAngularClient");
app.UseHttpsRedirection();

// Map health check endpoint
app.MapGet("/health", async (HttpContext context) =>
{
    var response = new HealthResponse
    {
        Status = "healthy",
        Timestamp = DateTime.UtcNow
    };
    
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsJsonAsync(response);
})
.WithName("HealthCheck")
.WithOpenApi()
.AllowAnonymous();

app.Run();
