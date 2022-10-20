using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services;

public interface IConversionService
{
    Task<IEnumerable<Conversion>> ListAsync();
    Task<Conversion> FindById(long id);
    Task<ConversionResponse> Create(Conversion conversion);
    Task<ConversionResponse> Delete(long id);
}