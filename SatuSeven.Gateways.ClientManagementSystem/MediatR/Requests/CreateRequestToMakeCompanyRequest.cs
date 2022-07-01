using MediatR;

namespace SatuSeven.Gateways.ClientManagementSystem.MediatR.Requests;

public class CreateRequestToMakeCompanyRequest : IRequest
{
    public string Name { get; set; }
    public string Details { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
}