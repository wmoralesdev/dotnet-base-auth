using Wame.Application.ViewModels.Common;

namespace Wame.Application.ViewModels.Users;

public class UserVm : BaseIdentityVm
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
}