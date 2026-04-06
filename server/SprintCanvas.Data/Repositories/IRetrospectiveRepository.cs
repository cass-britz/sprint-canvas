using SprintCanvas.Data.Domain;

namespace SprintCanvas.Data.Repositories;

public interface IRetrospectiveRepository
{
    Task<IEnumerable<Retrospective>> GetAllAsync();
    Task<Retrospective?> GetByIdAsync(string id);
    Task<Retrospective> CreateAsync(Retrospective retrospective);
    Task<Retrospective?> UpdateAsync(Retrospective retrospective);
    Task<bool> DeleteAsync(string id);
}
