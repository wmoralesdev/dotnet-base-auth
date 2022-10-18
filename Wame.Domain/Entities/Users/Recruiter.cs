using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Campaigns;
using Wame.Domain.Entities.Companies;

namespace Wame.Domain.Entities.Users;

public class Recruiter : BaseIdentity
{
    public Company? Company { get; set; }
    
    public string? EmployeeId { get; set; }
    
    public IList<Campaign>? Campaigns { get; set; }
}