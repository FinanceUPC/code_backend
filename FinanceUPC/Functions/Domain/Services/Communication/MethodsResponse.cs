using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Shared.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services.Communication;

public class MethodsResponse: BaseResponse<Methods>
{
    public MethodsResponse(Methods resource) : base(resource)
    {
    }

    public MethodsResponse(string message) : base(message)
    {
    }
}