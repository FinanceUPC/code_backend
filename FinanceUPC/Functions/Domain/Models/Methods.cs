using FinanceUPC.Security.Domain.Models;

namespace FinanceUPC.Functions.Domain.Models;

public class Methods
{
    public long Id { get; set; }
    public string Type { get; set; }
    
    public User User { get; set; }
    public long UserId { get; set; }
    public German German { get; set; } = new German();
    public Conversion Conversion { get; set; } = new Conversion();
}