using FinanceUPC.Functions.Domain.Models;

namespace FinanceUPC.Functions.Domain.Repositories;

public interface IConversionsRepository
{
    Task<IEnumerable<Conversion>> ListAsync();
    Task<Conversion> FindByConversionId(long id);
    Task Add(Conversion conversions);
    void Delete(Conversion conversions);
}