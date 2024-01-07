using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.Utility.Configurations;

namespace Qrdentity.Web.Data.Utility;

[EntityTypeConfiguration(typeof(CountryConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class Country : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string CountryCode { get; set; } = default!;

    public int SortOrder { get; set; }

    public ICollection<City> Cities { get; set; } = new List<City>();

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}