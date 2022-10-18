using Wame.Domain.Entities.Users;

namespace Wame.Domain.Entities.BaseIdentities;

public class BaseIdentity
{
    public Guid Id { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public UserRole Role { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
}