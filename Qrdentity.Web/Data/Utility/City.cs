using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Utility.Configurations;

namespace Qrdentity.Web.Data.Utility;

[EntityTypeConfiguration(typeof(CityConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class City : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid CountryId { get; set; }

    public string Name { get; set; } = default!;

    public string PlateNumber { get; set; } = default!;

    public Country Country { get; set; } = default!;

    public ICollection<District> Districts { get; set; } = new List<District>();

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}