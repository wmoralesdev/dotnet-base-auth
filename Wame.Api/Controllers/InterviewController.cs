using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wame.Api.Extensions;
using Wame.Application.Implementation.Interviews;
using Wame.Application.ViewModels;

namespace Wame.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class InterviewController : ControllerBase
{
    private readonly InterviewService _service;

    public InterviewController(InterviewService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public async Task<ActionResult<InterviewVm>> Create([FromBody] CreateInterviewVm vm)
    {
        var recruiterEmail = User.Claims.GetEmailFromClaims();

        return await _service.CreateInterview(recruiterEmail, vm);
    }

    [HttpPatch("complete")]
    public async Task<ActionResult<InterviewVm>> Complete([FromBody] InterviewVm vm)
    {
        return await _service.CompleteInterview(vm);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<InterviewVm>> Get(int id)
    {
        return await _service.GetInterview(id);
    }

    [HttpGet("candidate/{email}")]
    public async Task<ActionResult<IList<InterviewVm>>> GetCandidateInterviews(string email)
    {
        return Ok(await _service.GetCandidateInterviews(email));
    }
}