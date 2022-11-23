using Microsoft.EntityFrameworkCore;
using Wame.Application.Context;
using Wame.Application.ViewModels;
using Wame.Domain.Entities.Interviews;

namespace Wame.Application.Implementation.Interviews;

public class InterviewRepository
{
    private readonly AppDbContext _ctx;

    public InterviewRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Interview> Create(string candidateEmail, string recruiterEmail, int campaignId)
    {
        var interview = _ctx.Interviews.Add(new Interview
        {
            CreatedAt = DateTime.UtcNow,
            Candidate = await _ctx.Candidates.FirstOrDefaultAsync(c => c.Email!.Equals(candidateEmail)),
            Recruiter = await _ctx.Recruiters.FirstOrDefaultAsync(r => r.Email!.Equals(recruiterEmail)),
            Campaign = await _ctx.Campaigns.FirstOrDefaultAsync(c => c.Id == campaignId),
        }).Entity;

        await _ctx.SaveChangesAsync();

        return interview;
    }

    public async Task<Interview> CompleteInterview(Interview interview)
    {
        var current = await _ctx.Interviews.FirstOrDefaultAsync(i => i.Id == interview.Id);

        current!.General = interview.General ?? current.General;
        current.Aptitudes = interview.Aptitudes ?? current.Aptitudes;
        current.Strengths = interview.Strengths ?? current.Strengths;
        current.Weaknesses = interview.Weaknesses ?? current.Weaknesses;
        current.Qualifications = interview.Qualifications ?? current.Qualifications;
        current.Rating = interview.Rating ?? current.Rating;

        await _ctx.SaveChangesAsync();

        return current;
    }

    public async Task<Interview?> GetInterview(int id)
    {
        return await _ctx.Interviews.Include(i => i.Candidate)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IList<Interview>> GetCandidateInterviews(string email)
    {
        return await _ctx.Interviews
            .Include(i => i.Candidate)
            .Where(i => i.Candidate!.Email!.Equals(email))
            .ToListAsync();

    }
}