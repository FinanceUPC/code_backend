using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Resources;

namespace FinanceUPC.Functions.Mapping;

public class ResourceToModelProfile:AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveMethodsResource, Methods>();
    }
}