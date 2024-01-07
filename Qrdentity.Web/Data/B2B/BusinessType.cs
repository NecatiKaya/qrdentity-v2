using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(BusinessTypeConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class BusinessType : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string Descriptions { get; set; } = default!;

    public ICollection<BusinessSubType> SubTypes { get; } =
        new List<BusinessSubType>();

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}