using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.MultiFactor.Configuration;

internal sealed class MultiFactorRegistrationGroupConfiguration : IEntityTypeConfiguration<MultiFactorRegistrationGroup>
{
    public void Configure(EntityTypeBuilder<MultiFactorRegistrationGroup> builder)
    {
        builder.ToTable("MultiFactorRegistrationGroups", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);

        builder.Property(table => table.UserId).IsRequired();

        builder.HasMany<MultiFactorRegistrationSetting>(each => each.MultiFactorRegistrationSettings)
            .WithOne(each => each.MultiFactorRegistrationGroup)
            .IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}