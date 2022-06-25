using SatuSeven.Contracts.Abstract;

namespace SatuSeven.Company.Dal.Entities;

public class CompanyEntity : Entity 
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string LogoUrl { get; set; }
}