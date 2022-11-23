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
        CreateMap<FilledInviteVm, Candidate>()
            .ForMember(f => f.Aptitudes,
                opt => opt.MapFrom(
                    d => String.Join("\\", d.Aptitudes ?? new List<string?>()!))
            ).ForMember(f => f.Formation,
                opt => opt.MapFrom(
                    d => String.Join("\\", d.Formation ?? new List<string?>()!))
            ).ForMember(f => f.Experience,
                opt => opt.MapFrom(
                    d => String.Join("\\", d.Experience ?? new List<string?>()!))
            );
    }
}