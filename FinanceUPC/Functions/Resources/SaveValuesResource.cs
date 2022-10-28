using System.ComponentModel.DataAnnotations;

namespace FinanceUPC.Functions.Resources;

public class SaveValuesResource
{
    [Required]
    public int ExchangeRate { get; set; }
    [Required]
    public int FutureValue { get; set; }
    [Required]
    public int EffectiveRateTerm { get; set; }
    [Required]
    public int EffectiveRate { get; set; }
    [Required]
    public string InitialDate { get; set; }
    [Required]
    public string FinalDate { get; set; }
    [Required]
    public int Result { get; set; }
    
    [Required]
    public long MethodId { get; set; }
}