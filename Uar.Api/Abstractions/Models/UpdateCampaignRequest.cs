namespace Uar.Api.Abstractions.Models;

public record UpdateCampaignRequest(
    string CampaignName,
    string CampaignOwner,
    DateTime StartDate,
    DateTime EndDate,
    string Status
 );
