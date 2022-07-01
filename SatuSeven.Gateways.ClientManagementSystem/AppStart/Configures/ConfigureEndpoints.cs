using Microsoft.AspNetCore.HttpOverrides;

namespace SatuSeven.Gateways.ClientManagementSystem.AppStart.Configures;

public class ConfigureEndpoints
{
    /// <summary>
    /// Configure Routing
    /// </summary>
    /// <param name="app"></param>
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            
        });
    }
}