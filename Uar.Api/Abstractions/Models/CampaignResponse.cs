namespace Uar.Api.Abstractions.Models;

public record CampaignResponse(
    Guid Id,
    string CampaignName,
    string CampaignOwner,
    DateTime StartDate,
    DateTime EndDate,
    string Status
);