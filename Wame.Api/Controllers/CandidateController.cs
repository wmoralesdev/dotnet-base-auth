using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wame.Application.Implementation.Candidates;
using Wame.Application.ViewModels;

namespace Wame.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CandidateController : ControllerBase
{
    private readonly CandidateService _candidateService;

    public CandidateController(CandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost("invite/{invitationId:guid}")]
    public async Task<IActionResult> CreateFromInvite([FromBody] FilledInviteVm vm, Guid invitationId)
    {
        var candidate = await _candidateService.CreateCandidate(invitationId, vm);
        return Created(nameof(candidate), candidate);
    }
}