using SprintCanvas.Data.Domain;
using SprintCanvas.Data.Repositories;

namespace SprintCanvas.Data.Infrastructure;

public class RetrospectiveSeeder(IRetrospectiveRepository repository, IHostEnvironment env) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (!env.IsDevelopment()) return;

        var existing = await repository.GetAllAsync();
        if (existing.Any()) return;

        await repository.CreateAsync(new Retrospective
        {
            SprintId = "sprint-001",
            Theme = "Improve team communication",
            ActionItems =
            [
                "Hold daily standups at 9am",
                "Use async channels for non-urgent updates",
                "Run a short retro every Friday"
            ]
        });

        await repository.CreateAsync(new Retrospective
        {
            SprintId = "sprint-002",
            Theme = "Reduce technical debt",
            ActionItems =
            [
                "Allocate 20% of sprint capacity to refactoring",
                "Add missing unit tests for core logic",
                "Update outdated NuGet and npm dependencies"
            ]
        });
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
