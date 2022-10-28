using FinanceUPC.Functions.Domain.Models;

namespace FinanceUPC.Functions.Domain.Repositories;

public interface IValuesRepository
{
    Task<IEnumerable<Values>> ListAsync();
    Task<Values> FindByValuesId(long id);
    Task Add(Values values);
    void Delete(Values values);
}