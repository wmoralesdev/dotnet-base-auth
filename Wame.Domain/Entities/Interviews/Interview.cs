using Wame.Domain.Entities.Campaigns;
using Wame.Domain.Entities.Users;

namespace Wame.Domain.Entities.Interviews;

public class Interview
{
    public int Id { get; set; }
    
    public DateTime Schedule { get; set; }
    
    public Candidate? Candidate { get; set; }
    
    public Candidate? Recruiter { get; set; }
    
    public string? Annotations { get; set; }
    
    public Campaign? Campaign { get; set; }
    
    public InterviewStatus Status { get; set; }
}