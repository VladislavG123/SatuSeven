using AutoMapper;
using SatuSeven.Gateways.ClientManagementSystem.Bll.Dtos;
using SatuSeven.Gateways.ClientManagementSystem.Contracts.Parameters;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Entities;
using SatuSeven.Gateways.ClientManagementSystem.MediatR.RequestsAndNotifications.Company;

namespace SatuSeven.Gateways.ClientManagementSystem.AutoMapperProfiles;

public class CompanyProfiles : Profile
{
    public CompanyProfiles()
    {
        CreateMap<CreateRequestToMakeCompanyParameter, CreateRequestToMakeCompanyNotification>().ReverseMap();
        CreateMap<CompanyCreationDto, CreateRequestToMakeCompanyNotification>().ReverseMap();
        CreateMap<CompanyCreationDto, CompanyEntity>().ReverseMap();
    }
}