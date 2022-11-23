using Wame.Domain.Entities.Interviews;

namespace Wame.Application.ViewModels;

public class InterviewVm : Interview
{
    public new CandidateVm? Candidate { get; set; }

    public new CampaignVm? Campaign { get; set; }
}