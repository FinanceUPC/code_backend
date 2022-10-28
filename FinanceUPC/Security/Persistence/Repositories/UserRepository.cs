using Microsoft.EntityFrameworkCore;
using FinanceUPC.Security.Domain.Models;
using FinanceUPC.Security.Domain.Repositories;
using FinanceUPC.Shared.Persistence.Contexts;
using FinanceUPC.Shared.Persistence.Repositories;

namespace FinanceUPC.Security.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();

    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(long id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByEmailAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Email == username);
    }

    public bool ExistsByEmail(string username)
    {
        return _context.Users.Any(x => x.Email == username);
    }

    public User FindById(long id)
    {
        return _context.Users.Find(id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}