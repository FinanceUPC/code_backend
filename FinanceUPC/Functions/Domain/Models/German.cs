namespace FinanceUPC.Functions.Domain.Models;

public class German
{
    public long Id { get; set; }
    public float Amount { get; set; }
    public float MonthlyInterest { get; set; }
    public float InterestRate { get; set; }
    public string Period { get; set; }
    
    public Methods Methods { get; set; }
    public long MethodId { get; set; }
}