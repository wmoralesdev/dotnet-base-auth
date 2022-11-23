using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Wame.Domain.Entities.BaseIdentities;
using Wame.Domain.Entities.Campaigns;
using Wame.Domain.Entities.Interviews;
using Wame.Domain.Entities.Jobs;
using Wame.Domain.Entities.Users;

namespace Wame.Application.Context;

public class AppDbContext : DbContext
{
    public DbSet<BaseIdentity> BaseIdentities => Set<BaseIdentity>();

    public DbSet<Candidate> Candidates => Set<Candidate>();

    public DbSet<Recruiter> Recruiters => Set<Recruiter>();

    public DbSet<Job> Jobs => Set<Job>();

    public DbSet<Interview> Interviews => Set<Interview>();

    public DbSet<Campaign> Campaigns => Set<Campaign>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        builder.ApplyConfigurationsFromAssembly(Assembly.Load("Wame.Domain"));

        base.OnModelCreating(builder);
    }
}