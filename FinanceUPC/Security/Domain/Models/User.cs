using System.Text.Json.Serialization;
using FinanceUPC.Functions.Domain.Models;

namespace FinanceUPC.Security.Domain.Models;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
    
    public IList<Methods> Methods { get; set; } = new List<Methods>();
}