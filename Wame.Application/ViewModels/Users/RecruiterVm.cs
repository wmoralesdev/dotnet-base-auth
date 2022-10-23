using Wame.Application.ViewModels.Campaigns;
using Wame.Application.ViewModels.Common;
using Wame.Application.ViewModels.Companies;
using Wame.Domain.Entities.Companies;
using Wame.Domain.Entities.Users;

namespace Wame.Application.ViewModels.Users;

public class RecruiterVm : Recruiter
{
    public new CompanyVm? Company { get; set; }
    
    public new IList<CampaignVm>? Campaigns { get; set; }
}