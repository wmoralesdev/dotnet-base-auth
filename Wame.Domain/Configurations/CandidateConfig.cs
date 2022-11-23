using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wame.Domain.Entities.Users;

namespace Wame.Domain.Configurations;

public class CandidateConfig : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasOne(c => c.Campaign);
        builder.Property(c => c.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
    }
}