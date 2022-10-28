using FinanceUPC.Security.Domain.Models;

namespace FinanceUPC.Functions.Domain.Models;

public class Methods
{
    public long Id { get; set; }
    public string Type { get; set; }
    
    public User User { get; set; }
    public long UserId { get; set; }
    public List<German> German { get; set; } = new List<German>();
    public List<Conversion> Conversion { get; set; } = new List<Conversion>();
    public List<Values> Values { get; set; } = new List<Values>();
}