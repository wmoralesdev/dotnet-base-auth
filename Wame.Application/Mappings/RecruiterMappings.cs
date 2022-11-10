using AutoMapper;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Mappings;

public class RecruiterMappings : Profile
{
    public RecruiterMappings()
    {
        CreateMap<Recruiter, BaseIdentityVm>();
    }
}