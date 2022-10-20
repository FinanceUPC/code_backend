using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Domain.Services.Communication;
using FinanceUPC.Security.Domain.Repositories;
using FinanceUPC.Shared.Domain.Repositories;

namespace FinanceUPC.Functions.Services;

public class MethodsService: IMethodsService
{
    private readonly IUserRepository _userRepository;
    private readonly IMethodsRepository _methodsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MethodsService(IUserRepository userRepository, IMethodsRepository methodsRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _methodsRepository = methodsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Methods>> ListAsync()
    {
        return await _methodsRepository.ListAsync();
    }

    public async Task<Methods> FindByType(string type)
    {
        return await _methodsRepository.FindByMethodType(type);
    }

    public async Task<MethodsResponse> Create(Methods methods)
    {
        var userExist = await _userRepository.FindByIdAsync(methods.UserId);
        if (userExist == null)
            return new MethodsResponse($"The User is not exist");
        var methodExist = await _methodsRepository.FindByMethodType(methods.Type);
        if (methodExist != null)
            return new MethodsResponse($"The Method is exist");
        try
        {
            await _methodsRepository.Add(methods);
            await _unitOfWork.CompleteAsync();
            return new MethodsResponse(methods);
        }
        catch (Exception e)
        {
            return new MethodsResponse($"Failed to register a method: {e.Message}");
        }
    }

    public async Task<MethodsResponse> Delete(long id)
    {
        var existMethod = await _methodsRepository.FindByMethodId(id);
        if (existMethod == null)
            return new MethodsResponse("The Method not exist");
        try
        {
            _methodsRepository.Delete(existMethod);
            await _unitOfWork.CompleteAsync();
            return new MethodsResponse(existMethod);
        }
        catch (Exception e)
        {
            return new MethodsResponse($"Failed to find a current user Method: {e.Message}");
        }
    }
}