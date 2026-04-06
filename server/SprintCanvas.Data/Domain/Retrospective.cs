using Amazon.DynamoDBv2.DataModel;

namespace SprintCanvas.Data.Domain;

[DynamoDBTable("Retrospectives")]
public class Retrospective
{
    [DynamoDBHashKey]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string SprintId { get; set; } = string.Empty;

    public string Theme { get; set; } = string.Empty;

    public List<string> ActionItems { get; set; } = [];
}
