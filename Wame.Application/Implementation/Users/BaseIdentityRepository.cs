using Microsoft.EntityFrameworkCore;
using Wame.Application.Abstract.Users;
using Wame.Application.Context;
using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Implementation.Users;

public class BaseIdentityRepository : IBaseIdentityRepository
{
    private readonly AppDbContext _ctx;

    public BaseIdentityRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<BaseIdentity?> GetIdentityByEmail(string email)
    {
        return await _ctx.Candidates.Where(u => u.Email != null && u.Email.Equals(email)).FirstOrDefaultAsync();
    }

    public async Task<Candidate?> CreateCandidate(Candidate candidate)
    {
        var stored = _ctx.Candidates.Add(candidate);
        await _ctx.SaveChangesAsync();

        return stored.Entity;
    }
}