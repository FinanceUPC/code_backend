using FinanceUPC.Shared.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;

namespace FinanceUPC.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}