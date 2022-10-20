using AutoMapper;
using FinanceUPC.Functions.Domain.Models;
using FinanceUPC.Functions.Domain.Services;
using FinanceUPC.Functions.Resources;
using FinanceUPC.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceUPC.Functions.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class MethodsController: ControllerBase
{
    private readonly IMethodsService _methodsService;
    private readonly IMapper _mapper;

    public MethodsController(IMethodsService methodsService, IMapper mapper)
    {
        _methodsService = methodsService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<MethodsResource>> GetAllAsync()
    {
        var methods = await _methodsService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Methods>, IEnumerable<MethodsResource>>(methods);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<MethodsResource> GetAccountById(long id)
    {
        var methodsById = await _methodsService.FindById(id);
        var resources = _mapper.Map<Methods, MethodsResource>(methodsById);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _methodsService.Delete(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var businessProjectResource = _mapper.Map<Methods, MethodsResource>(result.Resource);

        return Ok(businessProjectResource);
    } 
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMethodsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var methods = _mapper.Map<SaveMethodsResource, Methods>(resource);

        var result = await _methodsService.Create(methods);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Methods, IMethodsService>(result.Resource);
        return Ok(clientResource);
    }
}