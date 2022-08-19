using SatuSeven.Contracts.Abstract;

namespace SatuSeven.Gateways.ClientManagementSystem.Dal.Entities;

public class CompanyEntity : Entity
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string LogoUrl { get; set; }
    public EntityStatus EntityStatus { get; set; }
}