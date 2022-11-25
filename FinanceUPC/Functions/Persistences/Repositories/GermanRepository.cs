using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;
using FinanceUPC.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceUPC.Functions.Persistences.Repositories;

public class GermanRepository: BaseRepository, IGermanRepository
{
    public GermanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<German>> ListAsync()
    {
        return await _context.Germans
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<German> FindByGermanId(long id)
    {
        return await _context.Germans
            .Include(p => p.User)
            .FirstOrDefaultAsync(p=>p.UserId == id);
    }
    public async Task<IEnumerable<German>> ListByUserId(long id)
    {
        return await _context.Germans.Where(p => p.UserId == id)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task Add(German german)
    {
        await _context.Germans.AddAsync(german);
    }

    public void Delete(German german)
    {
        _context.Germans.Remove(german);
    }
}