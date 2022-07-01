using MediatR;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.Requests;

namespace SatuSeven.Gateways.ClientManagementSystem.MediatR.RequestHandlers;

public class CreateRequestToMakeCompanyRequestHandler : IRequestHandler<CreateRequestToMakeCompanyRequest>
{
    public async Task<Unit> Handle(CreateRequestToMakeCompanyRequest request, CancellationToken cancellationToken)
    {
        
        return new Unit();
    }
}