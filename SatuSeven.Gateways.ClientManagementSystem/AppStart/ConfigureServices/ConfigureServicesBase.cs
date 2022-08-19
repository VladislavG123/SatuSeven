using FluentValidation.AspNetCore;
using MediatR;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesBase
{
    /// <summary>
    /// ConfigureServices Services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(typeof(Program));
        
        services.AddControllers().AddFluentValidation(s => 
        { 
            s.RegisterValidatorsFromAssemblyContaining<Program>(); 
        });
        
        services.AddMemoryCache();
        services.AddRouting();
        services.AddHttpContextAccessor();
        services.AddResponseCaching();
    }
}