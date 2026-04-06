using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace SprintCanvas.Data.Infrastructure;

public class DynamoDbTableInitializer(IAmazonDynamoDB dynamoDb) : IHostedService
{
    private const string TableName = "Retrospectives";

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var tables = await dynamoDb.ListTablesAsync(cancellationToken);
        if (tables.TableNames.Contains(TableName)) return;

        await dynamoDb.CreateTableAsync(new CreateTableRequest
        {
            TableName = TableName,
            AttributeDefinitions = [new AttributeDefinition("Id", ScalarAttributeType.S)],
            KeySchema = [new KeySchemaElement("Id", KeyType.HASH)],
            BillingMode = BillingMode.PAY_PER_REQUEST
        }, cancellationToken);

        while (!cancellationToken.IsCancellationRequested)
        {
            var description = await dynamoDb.DescribeTableAsync(TableName, cancellationToken);
            if (description.Table.TableStatus == TableStatus.ACTIVE) break;
            await Task.Delay(500, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
