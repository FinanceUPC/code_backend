using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Domain.Services.Communication;
using FinanceUPC.Shared.Domain.Repositories;

namespace FinanceUPC.Functions.Services;

public class GermanService: IGermanService
{
    private readonly IGermanRepository _germanRepository;
    private readonly IMethodsRepository _methodsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GermanService(IGermanRepository germanRepository, IMethodsRepository methodsRepository, IUnitOfWork unitOfWork)
    {
        _germanRepository = germanRepository;
        _methodsRepository = methodsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<German>> ListAsync()
    {
        return await _germanRepository.ListAsync();
    }

    public async Task<German> ListById(long id)
    {
        return await _germanRepository.FindByGermanId(id);
    }

    public async Task<GermanResponse> Create(German german)
    {
        var methodExist = await _methodsRepository.FindByMethodId(german.MethodId);
        if (methodExist == null)
            return new GermanResponse("The method is not exist");
        try
        {
            await _germanRepository.Add(german);
            await _unitOfWork.CompleteAsync();
            return new GermanResponse(german);
        }
        catch (Exception e)
        {
            return new GermanResponse($"Failed to register a German: {e.Message}");
        }
    }

    public async Task<GermanResponse> Delete(long id)
    {
        var GermanExist = await _germanRepository.FindByGermanId(id);

        if (GermanExist == null)
            return new GermanResponse("German not found.");
        try
        {
            _germanRepository.Delete(GermanExist);
            await _unitOfWork.CompleteAsync();

            return new GermanResponse(GermanExist);
        }
        catch (Exception e)
        {
            return new GermanResponse($"An error occurred while deleting the German: {e.Message}");
        }
    }
}