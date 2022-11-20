using System.ComponentModel.DataAnnotations;

namespace FinanceUPC.Functions.Resources;

public class SaveConversionsResource
{
    [Required]
    public string Type { get; set; }
    [Required]
    public float DaysAYear { get; set; }
    [Required]
    public float NominalRate { get; set; }
    [Required]
    public float NominalRateTerm { get; set; }
    [Required]
    public string CapitalizationPeriod { get; set; }
    [Required]
    public float EffectiveRateRequired { get; set; }
    [Required]
    public float Result { get; set; }
    
    [Required]
    public long MethodId { get; set; }
}