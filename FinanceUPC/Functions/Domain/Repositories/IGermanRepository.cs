using FinanceUPC.Functions.Domain.Models;

namespace FinanceUPC.Functions.Domain.Repositories;

public interface IGermanRepository
{
    Task<IEnumerable<German>> ListAsync();
    Task<IEnumerable<German>> ListByUserId(long id);
    Task<German> FindByGermanId(long id);
    Task Add(German german);
    void Delete(German german);
}