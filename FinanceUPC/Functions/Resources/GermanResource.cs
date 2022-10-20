namespace FinanceUPC.Functions.Resources;

public class GermanResource
{
    public long Id { get; set; }
    public float Amount { get; set; }
    public float MonthlyInterest { get; set; }
    public float InterestRate { get; set; }
    public string Period { get; set; }
    
    public MethodsResource Methods { get; set; }
    public long MethodId { get; set; }
}