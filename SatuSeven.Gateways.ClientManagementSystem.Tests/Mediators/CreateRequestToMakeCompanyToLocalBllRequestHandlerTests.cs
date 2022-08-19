using SatuSeven.Gateways.ClientManagementSystem.Bll.V1;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.NotificationHandlers.Company.Creation;
using Xunit;

namespace SatuSeven.Gateways.ClientManagementSystem.Tests.Mediators;

public class CreateRequestToMakeCompanyToLocalBllRequestHandlerTests
{
    [Fact]
    public async void Test1()
    {
        var a = nameof(CreateRequestToMakeCompanyToLocalBllRequestHandlerTests);
        var b = this.GetType().Name;
    }
}