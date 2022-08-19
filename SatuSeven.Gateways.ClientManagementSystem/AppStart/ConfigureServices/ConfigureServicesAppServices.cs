using SatuSeven.Gateways.ClientManagementSystem.Bll.Abstract;
using SatuSeven.Gateways.ClientManagementSystem.Bll.V1;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesAppServices
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICompanyBllService, CompanyBllService>();
    }
}