using Microsoft.EntityFrameworkCore;
using Wame.Application.Context;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Implementation.Recruiters;

public class RecruiterRepository
{
    private readonly AppDbContext _ctx;

    public RecruiterRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Recruiter?> FindByEmail(string email)
    {
        return await _ctx.Recruiters.FirstOrDefaultAsync(rec => rec.Email!.Equals(email));
    }
}