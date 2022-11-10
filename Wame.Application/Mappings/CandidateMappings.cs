using AutoMapper;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Mappings;

public class CandidateMappings : Profile
{
    public CandidateMappings()
    {
        CreateMap<Candidate, CandidateVm>();
        CreateMap<CandidateVm, Candidate>();
    }
}