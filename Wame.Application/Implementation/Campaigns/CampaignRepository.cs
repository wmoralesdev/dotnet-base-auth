using Microsoft.EntityFrameworkCore;
using Wame.Application.Context;
using Wame.Domain.Entities.Campaigns;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Implementation.Campaigns;

public class CampaignRepository
{
    private readonly AppDbContext _ctx;

    public CampaignRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Campaign> Create(Campaign campaign, Recruiter recruiter)
    {
        campaign.Recruiter = recruiter;
        campaign.IsActive = true;
        
        var entity = _ctx.Campaigns.Add(campaign).Entity;

        await _ctx.SaveChangesAsync();

        return entity;
    }

    public async Task<Campaign?> FindByInvitationId(Guid invitationId)
    {
        return await _ctx.Campaigns.FirstOrDefaultAsync(c => c.IsActive && c.InvitationId == invitationId);
    }

    public async Task<IList<Campaign>> GetCampaigns(string email)
    {
        return await _ctx.Campaigns
            .Include(c => c.Position)
            .Include(c => c.Recruiter)
            .Where(c => c.Recruiter!.Email!.Equals(email))
            .ToListAsync();
    }
}