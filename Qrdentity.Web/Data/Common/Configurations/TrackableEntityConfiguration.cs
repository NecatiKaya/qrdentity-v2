using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qrdentity.Web.Core.Converters;

namespace Qrdentity.Web.Data.Common.Configurations;

internal static class TrackableEntityConfiguration
{
    public static void Apply(EntityTypeBuilder builder)
    {
        builder.Property("CreatedDate").IsRequired()
            //.HasDefaultValue(DateTimeOffset.UtcNow)
            .HasValueGenerator<DateTimeOffsetValueGenerator>();
        builder.Property("IsActive").HasColumnType("boolean").IsRequired().HasDefaultValue(true);
    }
}