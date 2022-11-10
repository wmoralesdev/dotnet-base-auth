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
    public async Task<ActionResult<IList<CampaignVm>>> Get()
    {
        var email = User.Claims.GetEmailFromClaims();

        return Ok(await _campaignService.GetCampaigns(email));
    }
}