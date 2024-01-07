using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Qrdentity.Web.Core.Converters;

public sealed class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public DateTimeOffsetConverter()
        : base(
            d => d.ToUniversalTime(),
            d => d.ToUniversalTime())
    {
    }
}