namespace FinanceUPC.Functions.Domain.Models;

public class Values
{
    public long Id { get; set; }
    public int ExchangeRate { get; set; }
    public int FutureValue { get; set; }
    public int EffectiveRateTerm { get; set; }
    public int EffectiveRate { get; set; }
    public string InitialDate { get; set; }
    public string FinalDate { get; set; }
    public int Result { get; set; }
    
    public Methods Methods { get; set; }
    public long MethodId { get; set; }
}