using AutoMapper;
using Microsoft.Extensions.Logging;
using SatuSeven.Gateways.ClientManagementSystem.Bll.Abstract;
using SatuSeven.Gateways.ClientManagementSystem.Bll.Dtos;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Entities;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Providers.Abstract;

namespace SatuSeven.Gateways.ClientManagementSystem.Bll.V1;

public class CompanyBllService : ICompanyBllService
{
    private readonly ICompanyProvider _companyProvider;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CompanyBllService(ICompanyProvider companyProvider, IMapper mapper, 
        ILogger<CompanyBllService> logger)
    {
        _companyProvider = companyProvider ?? throw new ArgumentException(nameof(companyProvider));
        _mapper = mapper?? throw new ArgumentException(nameof(mapper));
        _logger = logger ?? throw new ArgumentException(nameof(logger));
    }
    public async Task CreateCompany(CompanyCreationDto parameter)
    {
        var entity = _mapper.Map<CompanyEntity>(parameter);
        entity.EntityStatus = EntityStatus.NotConfirmed;

        try
        {
            await _companyProvider.Add(entity);
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Exception handled from the provider: \"{e.Message}\"");
            throw;
        }
        
        _logger.LogInformation($"Company {{{parameter.Slug}}} created.");
    }
}