using Wame.Domain.Entities.Campaigns;
using Wame.Domain.Entities.Users;

namespace Wame.Domain.Entities.Interviews;

public class Interview
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public Candidate? Candidate { get; set; }
    
    public Recruiter? Recruiter { get; set; }
    
    public string? General { get; set; }
    
    public string? Aptitudes { get; set; }

    public string? Strengths { get; set; }
    
    public string? Weaknesses { get; set; }

    public string? Qualifications { get; set; }
    
    public int? Rating { get; set; }
    
    public Campaign? Campaign { get; set; }
}