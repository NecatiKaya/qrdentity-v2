using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.MultiFactor.Configuration;

namespace Qrdentity.Web.Data.MultiFactor;

[EntityTypeConfiguration(typeof(MultiFactorSettingConfiguration))]
public sealed class MultiFactorSetting : ITrackableEntity
{
    public string Id { get; set; } = default!;

    public string Descriptions { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}