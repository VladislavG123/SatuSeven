using MediatR;

namespace SatuSeven.Gateways.ClientManagementSystem.MediatR.RequestsAndNotifications.Company;

public class CreateRequestToMakeCompanyNotification : INotification
{
    public string Name { get; set; }
    public string Details { get; set; }
    public string LogoUrl { get; set; }
    public string Slug { get; set; }
}