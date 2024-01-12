using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.MultiFactor.Configuration;

namespace Qrdentity.Web.Data.MultiFactor;

[EntityTypeConfiguration(typeof(MultiFactorRegistrationGroupConfiguration))]
public sealed class MultiFactorRegistrationGroup : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public ICollection<MultiFactorRegistrationSetting> MultiFactorRegistrationSettings { get; set; } =
        new List<MultiFactorRegistrationSetting>();

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}