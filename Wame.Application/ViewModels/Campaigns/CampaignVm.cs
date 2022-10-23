using Wame.Application.ViewModels.Jobs;
using Wame.Application.ViewModels.Users;
using Wame.Domain.Entities.Campaigns;
using Wame.Domain.Entities.Users;

namespace Wame.Application.ViewModels.Campaigns;

public class CampaignVm : Campaign
{
    public new IList<CandidateVm>? Candidates { get; set; }
    
    public new RecruiterVm? Recruiter { get; set; }
    
    public new JobVm? Position { get; set; }
}