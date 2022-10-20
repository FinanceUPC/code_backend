using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Shared.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services.Communication;

public class ConversionResponse: BaseResponse<Conversion>
{
    public ConversionResponse(Conversion resource) : base(resource)
    {
    }

    public ConversionResponse(string message) : base(message)
    {
    }
}