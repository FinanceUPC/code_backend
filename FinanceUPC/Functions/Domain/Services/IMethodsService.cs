using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services;

public interface IMethodsService
{
    Task<IEnumerable<Methods>> ListAsync();
    Task<Methods> FindByType(string type);
    Task<MethodsResponse> Create(Methods methods);
    Task<MethodsResponse> Delete(long id);
}