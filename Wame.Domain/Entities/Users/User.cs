using Wame.Domain.Entities.BaseIdentities;

namespace Wame.Domain.Entities.Users;

public class User : BaseIdentity
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
}