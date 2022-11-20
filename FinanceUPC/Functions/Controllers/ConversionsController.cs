using AutoMapper;
using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Resources;
using FinanceUPC.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceUPC.Functions.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class Conversions: ControllerBase
{
    private readonly IConversionService _conversionService;
    private readonly IMapper _mapper;

    public Conversions(IConversionService conversionService, IMapper mapper)
    {
        _conversionService = conversionService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<ConversionResource>> GetAllAsync()
    {
        var conversions = await _conversionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Conversion>, IEnumerable<ConversionResource>>(conversions);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<ConversionResource> GetAccountById(long id)
    {
        var conversionById = await _conversionService.FindById(id);
        var resources = _mapper.Map<Conversion, ConversionResource>(conversionById);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _conversionService.Delete(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var conversionResource = _mapper.Map<Conversion, ConversionResource>(result.Resource);

        return Ok(conversionResource);
    } 
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveConversionsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var conversion = _mapper.Map<SaveConversionsResource, Conversion>(resource);
        System.Console.WriteLine("Hi");
        var result = await _conversionService.Create(conversion);
        System.Console.WriteLine("Hola");
        if (!result.Success)
            return BadRequest(result.Message);

        var conversionResource = _mapper.Map<Conversion, ConversionResource>(result.Resource);
        return Ok(conversionResource);
    }
}