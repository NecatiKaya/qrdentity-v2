using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.MultiFactor.Configuration;

internal sealed class MultiFactorRegistrationHistoryConfiguration : IEntityTypeConfiguration<MultiFactorRegistrationHistory>
{
    public void Configure(EntityTypeBuilder<MultiFactorRegistrationHistory> builder)
    {
        builder.ToTable("MultiFactorRegistrationHistory", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);
        
        builder.Property(mfr => mfr.UserId).IsRequired();
        builder.Property(mfr => mfr.UsedMobileNumber).HasColumnType("char(12)").IsRequired(false);
        builder.Property(mfr => mfr.UsedEmail).HasColumnType("varchar(50)").IsRequired(false);
        builder.Property(mfr => mfr.UserProvidedCode).HasColumnType("char(6)").IsRequired();

        TrackableEntityConfiguration.Apply(builder);
    }
}