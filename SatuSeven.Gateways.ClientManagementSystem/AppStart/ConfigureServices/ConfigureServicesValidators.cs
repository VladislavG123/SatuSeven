using FluentValidation;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;
using SatuSeven.Gateways.ClientManagementSystem.Validators;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesValidators
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateRequestToMakeCompanyParameterValidator>();
        
    }
}