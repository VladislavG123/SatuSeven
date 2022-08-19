using SatuSeven.Gateways.ClientManagementSystem.AppStart.Configures;
using SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

ConfigureServicesAppServices.ConfigureServices(builder.Services);
ConfigureServicesEntityProviders.ConfigureServices(builder.Services, builder.Configuration);

ConfigureServicesBase.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesSwagger.ConfigureServices(builder.Services, 
    builder.Configuration.GetSection("Swagger").Get<SwaggerOptions>());

ConfigureServicesCors.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureCommon.Configure(app, app.Environment);
ConfigureEndpoints.Configure(app, app.Environment);

app.Run();