using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(BusinessSubTypeConfiguration))]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class BusinessSubType : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string Descriptions { get; set; } = default!;

    public Guid BusinessTypeId { get; set; }

    public BusinessType BusinessType { get; set; } = null!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}