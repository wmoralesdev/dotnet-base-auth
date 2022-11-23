using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wame.Domain.Entities.Campaigns;

namespace Wame.Domain.Configurations;

public class CampaignConfig : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.HasMany(c => c.Candidates);
        builder.Property(c => c.InvitationId)
            .ValueGeneratedOnAdd();
    }
}