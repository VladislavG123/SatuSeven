using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

public class ConfigureServicesSwagger
{
    private const string AppTitle = "SatuSeven API";
    private const string AppDescription = "Web API for SatuSeven";
    private static readonly string AppVersion = $"q.0.0";
    private const string SwaggerConfig = "/swagger/v1/swagger.json";
    private const string SwaggerUrl = "api/manual";

    /// <summary>
    /// ConfigureServices Swagger services
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = AppTitle,
                Version = AppVersion,
                Description = AppDescription
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
        settings.SwaggerEndpoint(SwaggerConfig, $"{AppTitle} v.{AppVersion}");
        settings.RoutePrefix = SwaggerUrl;
        settings.HeadContent = $"";
        settings.DocumentTitle = $"{AppTitle}";
        settings.DefaultModelExpandDepth(0);
        settings.DefaultModelRendering(ModelRendering.Model);
        settings.DefaultModelsExpandDepth(0);
        settings.DocExpansion(DocExpansion.None);
        settings.DisplayRequestDuration();
        settings.OAuthAppName(AppTitle);
    }
}