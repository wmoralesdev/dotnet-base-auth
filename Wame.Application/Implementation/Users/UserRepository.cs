using Microsoft.EntityFrameworkCore;
using Wame.Application.Abstract.Users;
using Wame.Application.Context;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Implementation.Users;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _ctx;

    public UserRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }


    public async Task<User?> FindByEmail(string email)
    {
        return await _ctx.Users.Where(u => u.Email != null && u.Email.Equals(email)).FirstOrDefaultAsync();
    }

    public async Task<User?> Create(User user)
    {
        var stored = _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();

        return stored.Entity;
    }
}