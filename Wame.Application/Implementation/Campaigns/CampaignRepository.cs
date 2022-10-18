using Microsoft.EntityFrameworkCore;
using Wame.Application.Abstract.Campaigns;
using Wame.Application.Abstract.Jobs;
using Wame.Application.Abstract.Users;
using Wame.Application.Context;
using Wame.Domain.Entities.Campaigns;

namespace Wame.Application.Implementation.Campaigns;

public class CampaignRepository : ICampaignRepository
{
    private readonly AppDbContext _ctx;
    private readonly ICandidateRepository _candidateRepository;
    private readonly IJobRepository _jobRepository;

    public CampaignRepository(AppDbContext ctx, ICandidateRepository candidateRepository, IJobRepository jobRepository)
    {
        _ctx = ctx;
        _candidateRepository = candidateRepository;
        _jobRepository = jobRepository;
    }

    public async Task<Campaign> CreateCampaign(Campaign campaign)
    {
        var newCampaign = _ctx.Campaigns.Add(campaign);
        await _ctx.SaveChangesAsync();

        return newCampaign.Entity;
    }

    public async Task<Campaign?> GetCampaignById(int campaignId)
    {
        return await _ctx.Campaigns
            .Where(cmp => cmp.Id == campaignId)
            .Include(cmp => cmp.Candidates)
            .FirstOrDefaultAsync();
    }

    public async Task<IList<Campaign>> GetCampaigns()
    {
        return await _ctx.Campaigns
            .OrderBy(cmp => cmp.StartDate)
            .ToListAsync();
    }

    public async Task<IList<Campaign>> GetRecruiterCampaigns(string recruiterId)
    {
        return await _ctx.Campaigns
            .Include(cmp => cmp.Recruiter)
            .Where(cmp => cmp.Recruiter!.Email!.Equals(recruiterId))
            .ToListAsync();
    }

    public async Task<IList<Campaign>> GetCompanyCampaigns(int companyId)
    {
        return await _ctx.Campaigns
            .Include(cmp => cmp.Recruiter)
            .ThenInclude(rec => rec!.Company)
            .Where(cmp => cmp.Recruiter!.Company!.Id == companyId)
            .ToListAsync();
    }

    public async Task<Campaign> AddCandidateToCampaign(int campaignId, string candidateEmail)
    {
        var campaign = await GetCampaignById(campaignId);
        var candidate = await _candidateRepository.GetCandidateByEmail(candidateEmail);

        if (campaign!.Candidates!.Any(cand => cand.Email!.Equals(candidateEmail))) return campaign;

        campaign.Candidates!.Add(candidate);
        await _ctx.SaveChangesAsync();

        return campaign;
    }

    public async Task<Campaign> RemoveCandidateFromCampaign(int campaignId, string candidateEmail)
    {
        var campaign = await GetCampaignById(campaignId);
        
        campaign!.Candidates!.Remove(await _candidateRepository.GetCandidateByEmail(candidateEmail));
        await _ctx.SaveChangesAsync();
        
        return campaign;
    }

    public async Task<Campaign> UpdateCampaignStatus(int campaignId, bool status)
    {
        var campaign = await GetCampaignById(campaignId);

        campaign!.IsActive = status;
        await _ctx.SaveChangesAsync();

        return campaign;
    }

    public async Task<Campaign> ChangeCampaignJob(int campaignId, int jobId)
    {
        var campaign = await GetCampaignById(campaignId);
        var job = await _jobRepository.GetJobById(jobId);

        campaign!.Position = job;
        await _ctx.SaveChangesAsync();

        return campaign;
    }
}