using AutoMapper;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Campaigns;

namespace Wame.Application.Mappings;

public class CampaignMappings : Profile
{
    public CampaignMappings()
    {
        CreateMap<Campaign, CampaignVm>();
        CreateMap<NewCampaignVm, Campaign>();
        CreateMap<Campaign, ResumedCampaignVm>()
            .ForMember(d => d.Candidates,
                opt => opt.MapFrom(
                    e => e.Candidates.Count 
                )
            );
    }
}