using FinanceUPC.Security.Domain.Models;

namespace FinanceUPC.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(long id);
    Task<User> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    User FindById(long id);
    void Update(User user);
    void Remove(User user);
}