using AutoMapper;
using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Resources;
using FinanceUPC.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceUPC.Functions.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class ValuesController: ControllerBase
{
    private readonly IValuesService _valuesService;
    private readonly IMapper _mapper;

    public ValuesController(IValuesService valuesService, IMapper mapper)
    {
        _valuesService = valuesService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<ValuesResource>> GetAllAsync()
    {
        var values = await _valuesService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Values>, IEnumerable<ValuesResource>>(values);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _valuesService.Delete(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var germanResource = _mapper.Map<Values, ValuesResource>(result.Resource);

        return Ok(germanResource);
    } 
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveValuesResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var german = _mapper.Map<SaveValuesResource, Values>(resource);

        var result = await _valuesService.Create(german);

        if (!result.Success)
            return BadRequest(result.Message);

        var germanResource = _mapper.Map<Values, ValuesResource>(result.Resource);
        return Ok(germanResource);
    }
}