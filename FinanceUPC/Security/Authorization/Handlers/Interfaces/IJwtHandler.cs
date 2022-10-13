using FinanceUPC.Security.Domain.Models;

namespace FinanceUPC.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}