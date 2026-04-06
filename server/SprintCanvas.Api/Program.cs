using MediatR;
using SprintCanvas.Api.Common.Middleware;
using SprintCanvas.Api.Features.Health;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddMediatR(config => 
    config.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddHttpClient("DataService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["DataService:BaseUrl"] ?? "http://localhost:5001");
    client.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["DataService:ApiKey"]);
});

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

// Forward GraphQL requests to SprintCanvas.Data
app.MapPost("/graphql", async (HttpContext context, IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient("DataService");
    var requestContent = new StreamContent(context.Request.Body);
    requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

    var response = await client.PostAsync("/graphql", requestContent);

    context.Response.StatusCode = (int)response.StatusCode;
    context.Response.ContentType = response.Content.Headers.ContentType?.ToString() ?? "application/json";
    await response.Content.CopyToAsync(context.Response.Body);
}).AllowAnonymous();

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
