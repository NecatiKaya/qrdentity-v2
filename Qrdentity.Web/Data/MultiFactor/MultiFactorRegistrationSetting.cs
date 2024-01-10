using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.MultiFactor.Configuration;

namespace Qrdentity.Web.Data.MultiFactor;

[EntityTypeConfiguration(typeof(MultiFactorRegistrationSettingConfiguration))]
public sealed class MultiFactorRegistrationSetting : ITrackableEntity
{
    public Guid Id { get; set; }

    public Guid MultiFactorRegistrationId { get; set; }

    public string MultiFactorConfigurationId { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}