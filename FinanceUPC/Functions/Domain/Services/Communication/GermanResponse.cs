using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Shared.Domain.Services.Communication;

namespace FinanceUPC.Functions.Domain.Services.Communication;

public class GermanResponse: BaseResponse<German>
{
    public GermanResponse(German resource) : base(resource)
    {
    }

    public GermanResponse(string message) : base(message)
    {
    }
}