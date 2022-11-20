using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Domain.Services.Communication;
using FinanceUPC.Shared.Domain.Repositories;

namespace FinanceUPC.Functions.Services;

public class ValuesService: IValuesService
{
    private readonly IMethodsRepository _methodsRepository;
    private readonly IValuesRepository _valuesRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ValuesService(IMethodsRepository methodsRepository, IValuesRepository valuesRepository, IUnitOfWork unitOfWork)
    {
        _methodsRepository = methodsRepository;
        _valuesRepository = valuesRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Values>> ListAsync()
    {
        return await _valuesRepository.ListAsync();
    }

    public async Task<Values> FindById(long id)
    {
        return await _valuesRepository.FindByValuesId(id);
    }

    public async Task<ValuesResponse> Create(Values values)
    {
        var methodExist = await _methodsRepository.FindByMethodId(values.MethodId);
        if (methodExist == null)
            return new ValuesResponse($"The Method id is not exist");
        try
        {
            await _valuesRepository.Add(values);
            await _unitOfWork.CompleteAsync();
            return new ValuesResponse(values);
        }
        catch (Exception e)
        {
            return new ValuesResponse($"Failed to register a Method: {e.Message}");
        }
    }

    public async Task<ValuesResponse> Delete(long id)
    {
        var valuesExist = await _valuesRepository.FindByValuesId(id);
        if (valuesExist == null)
            return new ValuesResponse("Values is not exist");
        try
        {
            _valuesRepository.Delete(valuesExist);
            await _unitOfWork.CompleteAsync();
            return new ValuesResponse(valuesExist);
        }
        catch (Exception e)
        {
            return new ValuesResponse($"An Error occurred while deleting the Values");
        }
    }
}