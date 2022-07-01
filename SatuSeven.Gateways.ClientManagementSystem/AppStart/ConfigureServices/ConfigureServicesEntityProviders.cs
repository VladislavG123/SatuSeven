namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesEntityProviders
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // services.AddDbContext<ApplicationContext>(options =>
        //     options.UseNpgsql(configuration.GetConnectionString("PostgresDb")));
        //
        // services.AddScoped<ITaskProvider, EntityTaskProvider>();
        // services.AddScoped<IProjectProvider, EntityProjectProvider>();
        // services.AddScoped<IUserProvider, EntityUserProvider>();
    }
}