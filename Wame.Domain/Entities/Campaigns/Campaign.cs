using Wame.Domain.Entities.Jobs;
using Wame.Domain.Entities.Users;

namespace Wame.Domain.Entities.Campaigns;

public class Campaign
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public IList<Candidate>? Candidates { get; set; }
    
    public Recruiter? Recruiter { get; set; }
    
    public Job? Position { get; set; }
    
    public bool IsActive { get; set; }
}