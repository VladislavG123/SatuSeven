
using Microsoft.EntityFrameworkCore;
using SatuSeven.Gateways.ClientManagementSystem.Dal;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Providers.Abstract;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Providers.EntityFramework;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesEntityProviders
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Npgsql")));

        services.AddScoped<ICompanyProvider, CompanyEfProvider>();
    }
}