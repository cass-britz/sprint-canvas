using SprintCanvas.Data.Domain;
using SprintCanvas.Data.Repositories;

namespace SprintCanvas.Data.GraphQL;

public class Query
{
    public async Task<IEnumerable<Retrospective>> GetRetrospectivesAsync(
        [Service] IRetrospectiveRepository repository) =>
        await repository.GetAllAsync();

    public async Task<Retrospective?> GetRetrospectiveAsync(
        string id,
        [Service] IRetrospectiveRepository repository) =>
        await repository.GetByIdAsync(id);
}
