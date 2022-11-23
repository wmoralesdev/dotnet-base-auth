using AutoMapper;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Interviews;

namespace Wame.Application.Mappings;

public class InterviewMappings : Profile
{
    public InterviewMappings()
    {
        CreateMap<Interview, InterviewVm>();
        CreateMap<InterviewVm, Interview>();
    }
}