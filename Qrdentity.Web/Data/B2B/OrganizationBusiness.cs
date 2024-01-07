using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(OrganizationBusinessConfiguration))]
public sealed class OrganizationBusiness : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrganizationId { get; set; }

    public Guid BusinessSubTypeId { get; set; }

    public BusinessSubType BusinessSubType { get; set; } = default!;

    public Organization Organization { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}