using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uar.Api.Abstractions.Enums;
using Uar.Api.Abstractions.Models;
using Uar.Api.Services.Campaigns;

namespace Uar.Api.Controllers;

[EnableCors("Localhost")]
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class CampaignsController : ControllerBase
{
    private readonly ICampaignService _campaignService;

    public CampaignsController(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Campaign>> Get()
    {
        var campaigns = _campaignService.Get();
        return Ok(campaigns);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Campaign> GetById(Guid id)
    {
        var campaigns = _campaignService.GetById(id);
        return Ok(campaigns);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Campaign> Update(Guid id, UpdateCampaignRequest request)
    {
        var campaign = new Campaign()
        {
            Id = id,
            CampaignName = request.CampaignName,
            CampaignOwner = request.CampaignOwner,
            StartDate = request.StartDate.ToString(),
            EndDate = request.EndDate.ToString(),
            Status = request.Status
        };
        _campaignService.Update(campaign);
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateCampaign(CreateCampaignRequest request)
    {
        var campaign = new Campaign()
        {
            Id = Guid.NewGuid(),
            CampaignName = request.CampaignName,
            CampaignOwner = request.CampaignOwner,
            StartDate = request.StartDate.ToString(),
            EndDate = request.EndDate.ToString(),
            Status = Status.Preview.ToString()
        };

        _campaignService.Create(campaign);

        return CreatedAtAction(
            actionName: nameof(CreateCampaign),
            routeValues: new { id = campaign.Id },
            value: campaign
        );
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<Campaign> Delete(Guid id)
    {
        _campaignService.Delete(id);
        return NoContent();
    }
}
