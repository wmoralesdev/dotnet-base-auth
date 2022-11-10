using AutoMapper;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Jobs;

namespace Wame.Application.Mappings;

public class JobMappings : Profile
{
    public JobMappings()
    {
        CreateMap<Job, JobVm>();
        CreateMap<JobVm, Job>();
    }
}