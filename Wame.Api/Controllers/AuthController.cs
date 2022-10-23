using Microsoft.AspNetCore.Mvc;
using Wame.Application.Abstract.Users;
using Wame.Application.ViewModels.Auth;
using Wame.Application.ViewModels.Common;
using Wame.Application.ViewModels.Users;

namespace Wame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenVm>> Login(LoginVm loginVm)
    {
        return Ok(await _service.Login(loginVm));
    }

    [HttpPost("register/recruiter")]
    public async Task<ActionResult<RecruiterVm>> Register(RegisterRecruiterVm registerRecruiterVm)
    {
        return Ok(await _service.RegisterRecruiter(registerRecruiterVm));
    }
}