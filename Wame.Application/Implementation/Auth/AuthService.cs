using AutoMapper;
using Wame.Application.Exceptions;
using Wame.Application.Implementation.Recruiters;
using Wame.Application.Implementation.Tokens;
using Wame.Application.ViewModels;

namespace Wame.Application.Implementation.Auth;

public class AuthService
{
    private readonly RecruiterRepository _recruiterRepo;
    private readonly IMapper _mapper;
    private readonly TokenService _tokenService;

    public AuthService(RecruiterRepository recruiterRepo, IMapper mapper, TokenService tokenService)
    {
        _recruiterRepo = recruiterRepo;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<TokenVm> Login(LoginVm vm)
    {
        var user = await _recruiterRepo.FindByEmail(vm.Email);

        if (user is null) throw new NotFoundException("Recruiter not found");

        if (!user.Password!.Equals(vm.Password)) throw new WrongCredentialsException();

        return new TokenVm(_tokenService.GenerateToken(user));
    }
}