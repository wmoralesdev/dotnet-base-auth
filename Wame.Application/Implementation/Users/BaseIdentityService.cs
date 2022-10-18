using Wame.Application.Abstract;
using Wame.Application.Abstract.Tokens;
using Wame.Application.Abstract.Users;
using Wame.Application.Exceptions;
using Wame.Application.ViewModels.Auth;
using Wame.Application.ViewModels.Common;


namespace Wame.Application.Implementation.Users;

public class UserService : IUserService
{
    private readonly IBaseIdentityRepository _repo;
    private readonly ITokenService _token;

    public UserService(IBaseIdentityRepository repo, ITokenService token)
    {
        _repo = repo;
        _token = token;
    }

    public async Task<TokenVm> Login(LoginVm loginVm)
    {
        var user = await _repo.GetIdentityByEmail(loginVm.Email);

        if (user is null) throw new NotFoundException("User not found");

        if (user.Password != null || !user.Password!.Equals(loginVm.Password)) throw new WrongCredentialsException();

        return new TokenVm(_token.GenerateToken(user));
    }
}