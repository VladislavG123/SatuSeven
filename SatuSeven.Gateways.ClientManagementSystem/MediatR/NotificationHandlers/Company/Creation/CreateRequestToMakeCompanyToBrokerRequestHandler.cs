using MediatR;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.RequestsAndNotifications.Company;

namespace SatuSeven.Gateways.ClientManagementSystem.MediatR.NotificationHandlers.Company.Creation;

public class CreateRequestToMakeCompanyToBrokerRequestHandler
    : INotificationHandler<CreateRequestToMakeCompanyNotification>
{
    public async Task Handle(CreateRequestToMakeCompanyNotification request, CancellationToken cancellationToken)
    {
        //Thread.Sleep(1000);
    }
}