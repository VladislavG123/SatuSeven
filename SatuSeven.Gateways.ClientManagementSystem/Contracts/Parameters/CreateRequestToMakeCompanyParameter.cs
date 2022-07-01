using System.ComponentModel.DataAnnotations;

namespace SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;

public class CreateRequestToMakeCompanyParameter
{
    public string? Name { get; set; }
    public string? Details { get; set; }
    public string? ImageUrl { get; set; }
    public string? Slug { get; set; }
}