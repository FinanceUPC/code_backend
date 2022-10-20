namespace FinanceUPC.Functions.Resources;

public class ConversionsResource
{
    public long Id { get; set; }
    public string Type { get; set; }
    public float DaysAYear { get; set; }
    public float NominalRate { get; set; }
    public float NominalRateTerm { get; set; }
    public string CapitalizationPeriod { get; set; }
    public float EffectiveRateRequired { get; set; }
    public float Result { get; set; }
    
    public MethodsResource Methods { get; set; }
    public long MethodId { get; set; }
}