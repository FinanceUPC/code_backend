using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Resources;

namespace FinanceUPC.Profile.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Methods, MethodsResource>();
        CreateMap<German, GermanResource>();
        CreateMap<Conversion, GermanResource>();
    }
}