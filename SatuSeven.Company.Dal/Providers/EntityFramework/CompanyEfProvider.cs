using SatuSeven.Company.Dal.Entities;
using SatuSeven.Company.Dal.Providers.Abstract;
using SatuSeven.Contracts.Abstract.Providers.EntityFramework;

namespace SatuSeven.Company.Dal.Providers.EntityFramework;

public class CompanyEfProvider : EntityFrameworkProvider<ApplicationContext, CompanyEntity, Guid>, ICompanyProvider
{
    public CompanyEfProvider(ApplicationContext context) : base(context)
    {
    }
}