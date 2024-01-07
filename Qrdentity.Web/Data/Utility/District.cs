using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Utility.Configurations;

namespace Qrdentity.Web.Data.Utility;

[EntityTypeConfiguration(typeof(DistrictConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class District : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid CityId { get; set; }

    public string Name { get; set; } = default!;

    public City City { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}