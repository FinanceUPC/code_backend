using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Shared.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services.Communication;

public class ValuesResponse: BaseResponse<Values>
{
    public ValuesResponse(Values resource) : base(resource)
    {
    }

    public ValuesResponse(string message) : base(message)
    {
    }
}