namespace Uar.Api.Abstractions.Models;

public class Campaign
{
    public Guid Id { get; set; }
    public string CampaignName { get; set; }
    public string CampaignOwner { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Status { get; set; }
}
