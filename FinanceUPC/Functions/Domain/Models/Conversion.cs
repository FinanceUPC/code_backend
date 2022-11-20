namespace FinanceUPC.Functions.Domain.Models;

public class Conversion
{
    public long Id { get; set; }
    public string Type { get; set; }
    public float DaysAYear { get; set; }
    public float NominalRate { get; set; }
    public float NominalRateTerm { get; set; }
    public string CapitalizationPeriod { get; set; }
    public float EffectiveRateRequired { get; set; }
    public float Result { get; set; }
    
    public Methods Methods { get; set; }
    public long MethodId { get; set; }
}