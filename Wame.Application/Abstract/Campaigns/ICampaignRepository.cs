using Wame.Domain.Entities.Campaigns;

namespace Wame.Application.Abstract.Campaigns;

public interface ICampaignRepository
{
    Task<Campaign> CreateCampaign(Campaign campaign);

    Task<Campaign?> GetCampaignById(int campaignId);

    Task<IList<Campaign>> GetCampaigns();

    Task<IList<Campaign>> GetRecruiterCampaigns(string recruiterId);

    Task<IList<Campaign>> GetCompanyCampaigns(int companyId);

    Task<Campaign> AddCandidateToCampaign(int campaignId, string candidateEmail);

    Task<Campaign> RemoveCandidateFromCampaign(int campaignId, string candidateEmail);

    Task<Campaign> UpdateCampaignStatus(int campaignId, bool status);

    Task<Campaign> ChangeCampaignJob(int campaignId, int jobId);
}