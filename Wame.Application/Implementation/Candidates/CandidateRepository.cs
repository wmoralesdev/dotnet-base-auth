using Microsoft.EntityFrameworkCore;
using Wame.Application.Context;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Implementation.Candidates;

public class CandidateRepository
{
    private readonly AppDbContext _ctx;

    public CandidateRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Candidate> Create(Candidate candidate)
    {
        var entity = _ctx.Candidates.Add(candidate).Entity;
        await _ctx.SaveChangesAsync();

        return entity;
    }

    public async Task<Candidate?> Get(string email)
    {
        return await _ctx.Candidates.FirstOrDefaultAsync(c => c.Email!.Equals(email));
    }
}