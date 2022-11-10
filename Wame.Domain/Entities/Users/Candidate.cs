using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Campaigns;

namespace Wame.Domain.Entities.Users;

public class Candidate : BaseIdentity
{
    public IList<Campaign>? Campaigns { get; set; }
    
    public int Age { get; set; }
    
    public string? Phone { get; set; }
    
    public string? Experience { get; set; }
    
    public string? Formation { get; set; }
    
    public string? Aptitudes { get; set; }
}