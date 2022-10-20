using System.ComponentModel.DataAnnotations;

namespace FinanceUPC.Functions.Resources;

public class SaveMethodsResource
{
    [Required]
    [MaxLength(50)]
    public string Type { get; set; }
    
    [Required]
    public long UserId { get; set; }
}