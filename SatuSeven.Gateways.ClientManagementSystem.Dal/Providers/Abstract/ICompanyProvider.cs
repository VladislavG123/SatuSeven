using SatuSeven.Contracts.Abstract.Providers;

namespace SatuSeven.Gateways.ClientManagementSystem.Dal.Providers.Abstract;

public interface ICompanyProvider : ICrudProvider<Entities.CompanyEntity, Guid>
{
}