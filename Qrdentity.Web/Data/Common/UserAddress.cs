using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Common.Configurations;
using Qrdentity.Web.Data.Utility;

namespace Qrdentity.Web.Data.Common;

[EntityTypeConfiguration(typeof(UserAddressConfiguration))]
public sealed class UserAddress : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid DistrictId { get; set; }

    public string Address { get; set; } = default!;

    public string ZipCode { get; set; } = default!;

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string? GoogleMapsLink { get; set; }

    public District District { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}