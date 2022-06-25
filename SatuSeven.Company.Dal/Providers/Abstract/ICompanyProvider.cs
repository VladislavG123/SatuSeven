using SatuSeven.Contracts.Abstract.Providers;

namespace SatuSeven.Company.Dal.Providers.Abstract;

public interface ICompanyProvider : IReadProvider<Entities.CompanyEntity, Guid>
{
}