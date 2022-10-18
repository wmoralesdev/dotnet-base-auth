using Wame.Domain.Entities.Users;

namespace Wame.Domain.Entities.Companies;

public class Company
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public DateTime JoinedAt { get; set; }
    
    public IList<Recruiter>? Employees { get; set; }
}