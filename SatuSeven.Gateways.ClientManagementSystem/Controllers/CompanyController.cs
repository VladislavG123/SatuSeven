using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.Requests;

namespace SatuSeven.Gateways.ClientManagementSystem.Controllers;

[ApiController]
[Route("v1/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CompanyController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequestToMakeCompany(
        [FromBody] CreateRequestToMakeCompanyParameter parameter)
    {
        await _mediator.Send(_mapper.Map<CreateRequestToMakeCompanyRequest>(parameter));
        return Accepted();
    }
}