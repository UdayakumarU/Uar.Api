namespace Uar.Api.Abstractions.Models;

public record CreateCampaignRequest(
    string CampaignName,
    string CampaignOwner,
    string StartDate,
    string EndDate
 );
