using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services;

public interface IGermanService
{
    Task<IEnumerable<German>> ListAsync();
    Task<German> ListById(long id);
    Task<GermanResponse> Create(German german);
    Task<GermanResponse> Delete(long id);
}