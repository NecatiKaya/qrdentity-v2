using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(ContactInformationConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class ContactInformation : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrganizationId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public Organization Company { get; private set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}