using SatuSeven.Gateways.ClientManagementSystem.Bll.Dtos;

namespace SatuSeven.Gateways.ClientManagementSystem.Bll.Abstract;

public interface ICompanyBllService
{
    /// <summary>
    /// Creates company that needs to be approved later
    /// After creation it saved with flag 'NotConfirmed'
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    Task CreateCompany(CompanyCreationDto parameter);
}