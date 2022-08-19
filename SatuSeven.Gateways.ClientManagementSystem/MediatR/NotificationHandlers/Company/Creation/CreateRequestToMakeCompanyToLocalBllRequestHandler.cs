using AutoMapper;
using MediatR;
using SatuSeven.Gateways.ClientManagementSystem.Bll.Abstract;
using SatuSeven.Gateways.ClientManagementSystem.Bll.Dtos;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.RequestsAndNotifications.Company;

namespace SatuSeven.Gateways.ClientManagementSystem.MediatR.NotificationHandlers.Company.Creation;

public class CreateRequestToMakeCompanyToLocalBllRequestHandler 
    : INotificationHandler<CreateRequestToMakeCompanyNotification>
{
    private readonly ICompanyBllService _companyBllService;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateRequestToMakeCompanyToLocalBllRequestHandler(
        ICompanyBllService companyBllService, IMapper mapper, 
        ILogger<CreateRequestToMakeCompanyToLocalBllRequestHandler> logger)
    {
        _companyBllService = companyBllService ?? throw new ArgumentException(nameof(companyBllService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }

    public async Task Handle(CreateRequestToMakeCompanyNotification request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handled company: {{{request.Slug}}}");

        try
        {
            await _companyBllService.CreateCompany(_mapper.Map<CompanyCreationDto>(request));
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Exception handled: {e.Message}");
            throw;
        }

        _logger.LogInformation($"Success: {{{request.Slug}}}");

    }
}