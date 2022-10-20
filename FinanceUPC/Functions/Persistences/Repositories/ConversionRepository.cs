using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;
using FinanceUPC.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceUPC.Functions.Persistences.Repositories;

public class ConversionsRepository: BaseRepository, IConversionsRepository
{
    public ConversionsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Conversion>> ListAsync()
    {
        return await _context.Conversions
            .Include(p => p.MethodId)
            .ToListAsync();
    }

    public async Task<Conversion> FindByConversionId(long id)
    {
        return await _context.Conversions
            .Include(p => p.MethodId)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(Conversion conversions)
    {
        await _context.Conversions.AddAsync(conversions);
    }

    public void Delete(Conversion conversions)
    {
        _context.Conversions.Remove(conversions);
    }
}