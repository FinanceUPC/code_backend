using System.ComponentModel.DataAnnotations;

namespace FinanceUPC.Functions.Resources;

public class SaveGermanResource
{
    [Required]
    public float Amount { get; set; }
    [Required]
    public float MonthlyInterest { get; set; }
    [Required]
    public float InterestRate { get; set; }
    [Required]
    public string Period { get; set; }

    [Required]
    public long MethodId { get; set; }
}