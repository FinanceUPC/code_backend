using FinanceUPC.Security.Domain.Models;
using FinanceUPC.Security.Domain.Services.Communication;
using FinanceUPC.Security.Resources;

namespace FinanceUPC.Security.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}