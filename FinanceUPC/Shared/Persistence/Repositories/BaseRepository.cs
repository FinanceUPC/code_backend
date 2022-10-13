
using FinanceUPC.Shared.Persistence.Contexts;

namespace FinanceUPC.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}