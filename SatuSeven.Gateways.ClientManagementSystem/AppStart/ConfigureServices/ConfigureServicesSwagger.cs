using Microsoft.OpenApi.Models;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesSwagger
{
    private static SwaggerOptions _swaggerOptions;

    /// <summary>
    /// ConfigureServices Swagger services
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(IServiceCollection services, SwaggerOptions swaggerOptions)
    {
        _swaggerOptions = swaggerOptions;
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = _swaggerOptions.AppTitle,
                Version = _swaggerOptions.AppVersion,
                Description = _swaggerOptions.AppDescription
            });

            options.ResolveConflictingActions(x => x.First());
        });
    }

    /// <summary>
    /// Set up some properties for swagger UI for client
    /// </summary>
    /// <param name="settings"></param>
    public static void SwaggerSettings(SwaggerUIOptions settings)
    {
        settings.SwaggerEndpoint(_swaggerOptions.Config, 
            $"{_swaggerOptions.AppTitle} v.{_swaggerOptions.AppVersion}");
        settings.RoutePrefix = _swaggerOptions.Url;
        settings.HeadContent = $"";
        settings.DocumentTitle = $"{_swaggerOptions.AppTitle}";
        settings.DefaultModelExpandDepth(0);
        settings.DefaultModelRendering(ModelRendering.Model);
        settings.DefaultModelsExpandDepth(0);
        settings.DocExpansion(DocExpansion.None);
        settings.DisplayRequestDuration();
        settings.OAuthAppName(_swaggerOptions.AppTitle);
    }
}