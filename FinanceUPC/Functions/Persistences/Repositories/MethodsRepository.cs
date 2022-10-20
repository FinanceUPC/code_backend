using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;
using FinanceUPC.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceUPC.Functions.Persistences.Repositories;

public class MethodsRepository: BaseRepository, IMethodsRepository
{
    public MethodsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Methods>> ListAsync()
    {
        return await _context.Methods
            .Include(p => p.UserId)
            .ToListAsync();
    }

    public async Task<Methods> FindByMethodId(long id)
    {
        return await _context.Methods
            .Include(p => p.UserId)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Methods> FindByMethodType(string type)
    {
        return await _context.Methods
            .Include(p => p.UserId)
            .FirstOrDefaultAsync(p => p.Type == type);
    }

    public async Task Add(Methods methods)
    {
        await _context.Methods.AddAsync(methods);
    }

    public void Delete(Methods methods)
    {
        _context.Methods.Remove(methods);
    }
}