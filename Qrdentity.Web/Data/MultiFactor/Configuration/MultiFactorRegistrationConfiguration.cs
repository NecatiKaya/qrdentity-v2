using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Common.Configurations;

namespace Qrdentity.Web.Data.MultiFactor.Configuration;

internal sealed class MultiFactorRegistrationConfiguration : IEntityTypeConfiguration<MultiFactorRegistration>
{
    public void Configure(EntityTypeBuilder<MultiFactorRegistration> builder)
    {
        builder.ToTable("MultiFactorRegistrations", DataConstants.PublicSchema);
        builder.HasKey(table => table.Id);

        builder.Property(mfr => mfr.UserId).IsRequired();
        builder.Property(mfr => mfr.IsAuthenticated).IsRequired();
        builder.Property(mfr => mfr.CodeToAuthenticate).HasColumnType("char(6)").IsRequired();
        builder.Property(mfr => mfr.MobileNumberToSendCode).HasColumnType("char(12)").IsRequired(false);
        builder.Property(mfr => mfr.EmailToSendCode).HasColumnType("varchar(50)").IsRequired(false);

        TrackableEntityConfiguration.Apply(builder);
    }
}