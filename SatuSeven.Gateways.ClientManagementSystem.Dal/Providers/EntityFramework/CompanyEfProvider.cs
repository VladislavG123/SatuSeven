using SatuSeven.Contracts.Abstract.Providers.EntityFramework;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Entities;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Providers.Abstract;

namespace SatuSeven.Gateways.ClientManagementSystem.Dal.Providers.EntityFramework;

public class CompanyEfProvider : EntityFrameworkProvider<ApplicationContext, CompanyEntity, Guid>, ICompanyProvider
{
    public CompanyEfProvider(ApplicationContext context) : base(context)
    {
    }
}