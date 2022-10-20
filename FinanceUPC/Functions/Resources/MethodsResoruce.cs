using FinanceUPC.Security.Resources;

namespace FinanceUPC.Functions.Resources;

public class MethodsResource
{
    public long Id { get; set; }
    public string Type { get; set; }
    
    public UserResource User { get; set; }
    public long UserId { get; set; }
}