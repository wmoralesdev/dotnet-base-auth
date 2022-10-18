using Microsoft.AspNetCore.Mvc;
using Wame.Application.Abstract.Users;
using Wame.Application.ViewModels.Auth;
using Wame.Application.ViewModels.Common;

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
}