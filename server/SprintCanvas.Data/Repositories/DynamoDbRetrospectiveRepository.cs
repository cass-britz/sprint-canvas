using Amazon.DynamoDBv2.DataModel;
using SprintCanvas.Data.Domain;

namespace SprintCanvas.Data.Repositories;

public class DynamoDbRetrospectiveRepository(IDynamoDBContext context) : IRetrospectiveRepository
{
    public async Task<IEnumerable<Retrospective>> GetAllAsync() =>
        await context.ScanAsync<Retrospective>([]).GetRemainingAsync();

    public async Task<Retrospective?> GetByIdAsync(string id) =>
        await context.LoadAsync<Retrospective>(id);

    public async Task<Retrospective> CreateAsync(Retrospective retrospective)
    {
        retrospective.Id = Guid.NewGuid().ToString();
        await context.SaveAsync(retrospective);
        return retrospective;
    }

    public async Task<Retrospective?> UpdateAsync(Retrospective retrospective)
    {
        var existing = await context.LoadAsync<Retrospective>(retrospective.Id);
        if (existing is null) return null;

        await context.SaveAsync(retrospective);
        return retrospective;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var existing = await context.LoadAsync<Retrospective>(id);
        if (existing is null) return false;

        await context.DeleteAsync<Retrospective>(id);
        return true;
    }
}
