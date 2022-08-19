using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.RequestsAndNotifications.Company;

namespace SatuSeven.Gateways.ClientManagementSystem.Controllers;

[ApiController]
[Route("v1/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IValidator<CreateRequestToMakeCompanyParameter> _createRequestToMakeCompanyParameterValidator;

    public CompanyController(IMapper mapper, IMediator mediator,
        IValidator<CreateRequestToMakeCompanyParameter> createRequestToMakeCompanyParameterValidator)
    {
        _mapper = mapper;
        _mediator = mediator;
        _createRequestToMakeCompanyParameterValidator = createRequestToMakeCompanyParameterValidator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequestToMakeCompany(
        [FromBody] CreateRequestToMakeCompanyParameter parameter)
    {
        var validation = await _createRequestToMakeCompanyParameterValidator.ValidateAsync(parameter);
        if (!validation.IsValid)
        {
            return ValidationProblem(validation.ToString());
        }

        await _mediator.Publish(_mapper.Map<CreateRequestToMakeCompanyNotification>(parameter));
        
        return Accepted();
    }
}