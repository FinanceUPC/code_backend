using FinanceUPC.Functions.Domain.Models;

namespace FinanceUPC.Functions.Domain.Repositories;

public interface IMethodsRepository
{
    Task<IEnumerable<Methods>> ListAsync();
    Task<Methods> FindByMethodType(string type);
    Task<Methods> FindByMethodId(long id);
    Task Add(Methods methods);
    void Delete(Methods methods);
}