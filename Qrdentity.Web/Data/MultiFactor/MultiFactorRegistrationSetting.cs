using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.MultiFactor.Configuration;

namespace Qrdentity.Web.Data.MultiFactor;

[EntityTypeConfiguration(typeof(MultiFactorRegistrationSettingConfiguration))]
public sealed class MultiFactorRegistrationSetting : ITrackableEntity
{
    public Guid Id { get; set; }

    public Guid MultiFactorRegistrationGroupId { get; set; }

    public string MultiFactorSettingId { get; set; } = default!;

    public string Value { get; set; } = default!;

    public string CodeToAuthenticate { get; set; } = default!;

    public bool IsAuthenticated { get; set; }

    public MultiFactorRegistrationGroup MultiFactorRegistrationGroup { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}