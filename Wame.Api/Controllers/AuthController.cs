using Microsoft.AspNetCore.Mvc;
using Wame.Application.Implementation.Auth;
using Wame.Application.ViewModels;

namespace Wame.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _service;
    
    public AuthController(AuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenVm>> Login(LoginVm loginVm)
    {
        return Ok(await _service.Login(loginVm));
    }
}