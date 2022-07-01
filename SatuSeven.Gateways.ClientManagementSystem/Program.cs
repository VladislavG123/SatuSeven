using SatuSeven.Gateways.ClientManagementSystem.AppStart.Configures;
using SatuSeven.Gateways.ClientManagementSystem.AppStart.ConfigureServices;

var builder = WebApplication.CreateBuilder(args);

ConfigureServicesAppServices.ConfigureServices(builder.Services);
ConfigureServicesEntityProviders.ConfigureServices(builder.Services, builder.Configuration);

ConfigureServicesBase.ConfigureServices(builder.Services, builder.Configuration);
ConfigureServicesSwagger.ConfigureServices(builder.Services);
ConfigureServicesCors.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureCommon.Configure(app, app.Environment);
ConfigureEndpoints.Configure(app, app.Environment);

app.Run();