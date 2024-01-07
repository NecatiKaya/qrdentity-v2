using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;
using Qrdentity.Web.Data.Utility;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(OrganizationAddressConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class OrganizationAddress : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrganizationId { get; set; }

    public Guid DistrictId { get; set; }

    public string Address { get; set; } = default!;

    public string ZipCode { get; set; } = default!;

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string? GoogleMapsLink { get; set; }

    public Organization Organization { get; set; } = default!;

    public District District { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}