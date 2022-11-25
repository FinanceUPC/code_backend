using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Repositories;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Domain.Services.Communication;
using FinanceUPC.Security.Domain.Repositories;
using FinanceUPC.Shared.Domain.Repositories;

namespace FinanceUPC.Functions.Services;

public class GermanService: IGermanService
{
    private readonly IGermanRepository _germanRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public GermanService(IGermanRepository germanRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _germanRepository = germanRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<German>> ListAsync()
    {
        return await _germanRepository.ListAsync();
    }

    public async Task<German> ListById(long id)
    {
        return await _germanRepository.FindByGermanId(id);
    }

    public async Task<IEnumerable<German>> ListByUserId(long id)
    {
        return await _germanRepository.ListByUserId(id);
    }

    public async Task<GermanResponse> Create(German german)
    {
        var existingUser = await _userRepository.FindByIdAsync(german.UserId);
        if (existingUser == null)
            return new GermanResponse("Invalid user");
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