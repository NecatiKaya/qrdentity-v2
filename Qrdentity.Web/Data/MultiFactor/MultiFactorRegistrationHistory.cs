using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.MultiFactor.Configuration;

namespace Qrdentity.Web.Data.MultiFactor;

[EntityTypeConfiguration(typeof(MultiFactorRegistrationHistoryConfiguration))]
public sealed class MultiFactorRegistrationHistory : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public string? UsedMobileNumber { get; set; }

    public string? UsedEmail { get; set; }

    public string UserProvidedCode { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    [NotMapped] public DateTimeOffset? ModifiedDate { get; set; }

    [NotMapped] public Guid? UpdatedBy { get; set; }

    [NotMapped] public bool IsActive { get; set; }
}