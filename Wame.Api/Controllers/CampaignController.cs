using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wame.Api.Extensions;
using Wame.Application.Implementation.Campaigns;
using Wame.Application.ViewModels;

namespace Wame.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CampaignController : ControllerBase
{
    private readonly CampaignService _campaignService;

    public CampaignController(CampaignService campaignService)
    {
        _campaignService = campaignService;
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost("create")]
    public async Task<ActionResult<CampaignVm>> Create([FromBody] NewCampaignVm vm)
    {
        var email = User.Claims.GetEmailFromClaims();

        return await _campaignService.CreateCampaign(email, vm);
    }

    [HttpGet]
    public async Task<ActionResult<IList<ResumedCampaignVm>>> Get()
    {
        var email = User.Claims.GetEmailFromClaims();

        return Ok(await _campaignService.GetCampaigns(email));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CampaignVm>> GetById(int id)
    {
        return Ok(await _campaignService.GetById(id));
    }

    [AllowAnonymous]
    [HttpGet("invite/{invitationId:guid}")]
    public async Task<ActionResult<CampaignVm>> GetByInvitationId(Guid invitationId)
    {
        return Ok(await _campaignService.GetByInvitationId(invitationId));
    }

    [HttpPatch("disable/{id:int}")]
    public async Task<ActionResult<CampaignVm>> Disable(int id)
    {
        return Ok(await _campaignService.DisableCampaign(id));
    }
}