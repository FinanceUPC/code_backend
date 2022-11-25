using FinanceUPC.Security.Resources;

namespace FinanceUPC.Functions.Resources;

public class GermanResource
{
    public long Id { get; set; }
    public string CreatedAt { get; set; }
    public string Transmitter { get; set; }
    public string Receptor { get; set; }
    public float TotalI { get; set; }
    public float TotalF { get; set; }
    public float PartialI { get; set; }
    public float PartialF { get; set; }
    public float Price { get; set; }
    public float Years { get; set; }
    public float Frequent { get; set; }
    public float Days { get; set; }
    public float TEA { get; set; }
    public float IGV { get; set; }
    public float Rent { get; set; }
    public float Buyback { get; set; }
    public float Notarial { get; set; }
    public float Registral { get; set; }
    public float Tasation { get; set; }
    public float Study { get; set; }
    public float Active { get; set; }
    public float Period { get; set; }
    public float Risk { get; set; }
    public float COK { get; set; }
    public float WACC { get; set; }
    
    
    public UserResource User { get; set; }
    public long UserId { get; set; }
}