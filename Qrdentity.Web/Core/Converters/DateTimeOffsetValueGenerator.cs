using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Qrdentity.Web.Core.Converters;

internal sealed class DateTimeOffsetValueGenerator : ValueGenerator
{
    protected override object? NextValue(EntityEntry entry)
    {
        return DateTimeOffset.UtcNow;
    }

    public override bool GeneratesTemporaryValues => false;
}