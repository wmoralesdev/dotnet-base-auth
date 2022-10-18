using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wame.Domain.Entities.BaseIdentities;

namespace Wame.Domain.Configurations.BaseIdentities;

public class BaseIdentityConfig : IEntityTypeConfiguration<BaseIdentity>
{
    public void Configure(EntityTypeBuilder<BaseIdentity> builder)
    {
        builder.HasKey(prop => prop.Id);
        builder.HasKey(prop => prop.Email);
    }
}