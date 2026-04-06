using SprintCanvas.Data.Domain;
using SprintCanvas.Data.Repositories;

namespace SprintCanvas.Data.GraphQL;

public record CreateRetrospectiveInput(string SprintId, string Theme, List<string> ActionItems);

public record UpdateRetrospectiveInput(string Id, string? SprintId, string? Theme, List<string>? ActionItems);

public class Mutation
{
    public async Task<Retrospective> CreateRetrospectiveAsync(
        CreateRetrospectiveInput input,
        [Service] IRetrospectiveRepository repository) =>
        await repository.CreateAsync(new Retrospective
        {
            SprintId = input.SprintId,
            Theme = input.Theme,
            ActionItems = input.ActionItems
        });

    public async Task<Retrospective?> UpdateRetrospectiveAsync(
        UpdateRetrospectiveInput input,
        [Service] IRetrospectiveRepository repository)
    {
        var existing = await repository.GetByIdAsync(input.Id);
        if (existing is null) return null;

        existing.SprintId = input.SprintId ?? existing.SprintId;
        existing.Theme = input.Theme ?? existing.Theme;
        existing.ActionItems = input.ActionItems ?? existing.ActionItems;

        return await repository.UpdateAsync(existing);
    }

    public async Task<bool> DeleteRetrospectiveAsync(
        string id,
        [Service] IRetrospectiveRepository repository) =>
        await repository.DeleteAsync(id);
}
