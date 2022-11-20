using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;
using FinanceUPC.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceUPC.Functions.Persistences.Repositories;

public class ValuesRepository: BaseRepository, IValuesRepository
{
    public ValuesRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Values>> ListAsync()
    {
        return await _context.Values
            .Include(p => p.Methods)
            .ToListAsync();
    }

    public async Task<Values> FindByValuesId(long id)
    {
        return await _context.Values
            .Include(p => p.Methods)
            .FirstOrDefaultAsync(p=>p.Id == id);
    }

    public async Task Add(Values german)
    {
        await _context.Values.AddAsync(german);
    }

    public void Delete(Values german)
    {
        _context.Values.Remove(german);
    }
}