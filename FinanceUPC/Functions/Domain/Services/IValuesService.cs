using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services;

public interface IValuesService
{
    Task<IEnumerable<Values>> ListAsync();
    Task<Values> FindById(long id);
    Task<ValuesResponse> Create(Values values);
    Task<ValuesResponse> Delete(long id);
}