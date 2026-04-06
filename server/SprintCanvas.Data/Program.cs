using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using SprintCanvas.Data.GraphQL;
using SprintCanvas.Data.Infrastructure;
using SprintCanvas.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

var awsSection = builder.Configuration.GetSection("Aws");
var region = awsSection["Region"] ?? "us-east-1";
var serviceUrl = awsSection["ServiceUrl"];

var dynamoConfig = new AmazonDynamoDBConfig { RegionEndpoint = RegionEndpoint.GetBySystemName(region) };

if (!string.IsNullOrEmpty(serviceUrl))
{
    dynamoConfig.ServiceURL = serviceUrl;
    builder.Services.AddSingleton<IAmazonDynamoDB>(
        new AmazonDynamoDBClient(new BasicAWSCredentials("local", "local"), dynamoConfig));
    builder.Services.AddHostedService<DynamoDbTableInitializer>();
}
else
{
    builder.Services.AddSingleton<IAmazonDynamoDB>(new AmazonDynamoDBClient(dynamoConfig));
}

builder.Services.AddSingleton<IDynamoDBContext>(sp =>
    new DynamoDBContextBuilder()
        .WithDynamoDBClient(() => sp.GetRequiredService<IAmazonDynamoDB>())
        .Build());

builder.Services.AddScoped<IRetrospectiveRepository, DynamoDbRetrospectiveRepository>();
builder.Services.AddHostedService<RetrospectiveSeeder>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.UseMiddleware<ApiKeyMiddleware>();
app.MapGraphQL();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
