using Uar.Api.Abstractions.Models;

namespace Uar.Api.Services.Campaigns;

public interface ICampaignService
{
    IEnumerable<Campaign> Get();
    Campaign? GetById(Guid id);
    void Create(Campaign campaign);
    void Update(Campaign campaign);
    void Delete(Guid id);
}
