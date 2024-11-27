using Uar.Api.Abstractions.Models;
using Uar.Api.Data;

namespace Uar.Api.Services.Campaigns;

public class CampaignService : ICampaignService
{
    private readonly ApiDbContext _appDbContext;

    public CampaignService(ApiDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Create(Campaign campaign)
    {
        _appDbContext.Campaigns.Add(campaign);
        _appDbContext.SaveChanges();
    }

    public IEnumerable<Campaign> Get()
    {
        return _appDbContext.Campaigns.Select(campaign => new Campaign()
        {
            Id = campaign.Id,
            CampaignName = campaign.CampaignName,
            CampaignOwner = campaign.CampaignOwner,
            StartDate = campaign.StartDate,
            EndDate = campaign.EndDate,
            Status = campaign.Status
        });
    }

    public Campaign? GetById(Guid id)
    {
        return Get().Where(campaign => campaign.Id.Equals(id)).FirstOrDefault();
    }

    public void Delete(Guid id)
    {
        var campaign = _appDbContext.Campaigns.Single(b => b.Id == id);
        _appDbContext.Campaigns.Remove(campaign);
        _appDbContext.SaveChanges();
    }

    public void Update(Campaign campaign)
    {
        var campaignRecord = _appDbContext.Campaigns.Single(b => b.Id == campaign.Id);

        campaignRecord.CampaignName = campaign.CampaignName;
        campaignRecord.CampaignOwner = campaign.CampaignOwner;
        campaignRecord.StartDate = campaign.StartDate;
        campaignRecord.EndDate = campaign.EndDate;
        campaignRecord.Status = campaign.Status;

        _appDbContext.SaveChanges();
    }
}
