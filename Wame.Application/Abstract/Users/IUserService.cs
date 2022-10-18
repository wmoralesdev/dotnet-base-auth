using Wame.Application.ViewModels.Auth;
using Wame.Application.ViewModels.Common;
using Wame.Application.ViewModels.Users;

namespace Wame.Application.Abstract.Users;

public interface IUserService
{
    Task<TokenVm> Login(LoginVm loginVm);
}