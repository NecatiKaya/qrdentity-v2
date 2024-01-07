using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Qrdentity.Web.Data.Common.Configurations;

internal static class TrackableEntityConfiguration
{
    public static void Apply(EntityTypeBuilder builder)
    {
        builder.Property("CreatedDate").IsRequired()
            .HasDefaultValue(DateTimeOffset.UtcNow)
            .ValueGeneratedOnAddOrUpdate();
        builder.Property("IsActive").HasColumnType("boolean").IsRequired().HasDefaultValue(true);
    }
}