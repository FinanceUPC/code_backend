using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Domain.Services.Communication;
using FinanceUPC.Shared.Domain.Repositories;

namespace FinanceUPC.Functions.Services;

public class ConversionsService: IConversionService
{
    private readonly IConversionsRepository _conversionsRepository;
    private readonly IMethodsRepository _methodsRepository;
    private readonly IUnitOfWork _unitOfWork;


    public ConversionsService(IConversionsRepository conversionsRepository, IMethodsRepository methodsRepository, IUnitOfWork unitOfWork)
    {
        _conversionsRepository = conversionsRepository;
        _methodsRepository = methodsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Conversion>> ListAsync()
    {
        return await _conversionsRepository.ListAsync();
    }

    public async Task<Conversion> FindById(long id)
    {
        return await _conversionsRepository.FindByConversionId(id);
    }

    public async Task<ConversionResponse> Create(Conversion conversion)
    {
        var methodExist = await _methodsRepository.FindByMethodId(conversion.MethodId);
        if (methodExist == null)
            return new ConversionResponse("The method is not exist");
        try
        {
            await _conversionsRepository.Add(conversion);
            await _unitOfWork.CompleteAsync();
            return new ConversionResponse(conversion);
        }
        catch (Exception e)
        {   
            return new ConversionResponse($"Failed to register a Conversion: {e.Message}");
        }
    }

    public async Task<ConversionResponse> Delete(long id)
    {
        var ConversionExist = await _conversionsRepository.FindByConversionId(id);

        if (ConversionExist == null)
            return new ConversionResponse("German not found.");
        try
        {
            _conversionsRepository.Delete(ConversionExist);
            await _unitOfWork.CompleteAsync();

            return new ConversionResponse(ConversionExist);
        }
        catch (Exception e)
        {
            return new ConversionResponse($"An error occurred while deleting the Conversion: {e.Message}");

        }
    }
}