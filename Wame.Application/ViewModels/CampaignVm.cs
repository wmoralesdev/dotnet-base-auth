using Wame.Domain.Entities.Campaigns;

namespace Wame.Application.ViewModels;

public class CampaignVm : Campaign
{
    public new IList<CandidateVm>? Candidates { get; set; }
    
    public new BaseIdentityVm? Recruiter { get; set; }
    
    public new JobVm? Position { get; set; }
    
    public new CandidateVm? Hired { get; set; }
}