using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.Load("Wame.Domain"));

        base.OnModelCreating(builder);
    }
}