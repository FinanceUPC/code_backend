using AutoMapper;
using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Resources;
using FinanceUPC.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceUPC.Functions.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class GermanController: ControllerBase
{
    private readonly IGermanService _germanService;
    private readonly IMapper _mapper;

    public GermanController(IGermanService germanService, IMapper mapper)
    {
        _germanService = germanService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<GermanResource>> GetAllAsync()
    {
        var germans = await _germanService.ListAsync();
        var resources = _mapper.Map<IEnumerable<German>, IEnumerable<GermanResource>>(germans);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _germanService.Delete(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var germanResource = _mapper.Map<German, GermanResource>(result.Resource);

        return Ok(germanResource);
    } 
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveGermanResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var german = _mapper.Map<SaveGermanResource, German>(resource);

        var result = await _germanService.Create(german);

        if (!result.Success)
            return BadRequest(result.Message);

        var germanResource = _mapper.Map<German, GermanResource>(result.Resource);
        return Ok(germanResource);
    }
}