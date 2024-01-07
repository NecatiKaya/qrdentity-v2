using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Utility.Configurations;

namespace Qrdentity.Web.Data.Utility;

[EntityTypeConfiguration(typeof(TaxOfficeConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class TaxOffice : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid DistrictId { get; set; }

    public string OfficeName { get; set; } = null!;

    public int SortOrder { get; set; }

    public string PlateNumber { get; set; } = null!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}