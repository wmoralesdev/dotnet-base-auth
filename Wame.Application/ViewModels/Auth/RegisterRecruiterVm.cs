using Wame.Domain.Entities.Users;

namespace Wame.Application.ViewModels.Auth;

public class RegisterRecruiterVm
{
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public UserRole Role { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
}