using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(OrganizationAgreementConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class OrganizationAgreement : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrganizationId { get; set; }

    public string FileName { get; set; } = default!;

    public string FileExtension { get; set; } = default!;

    public int FileLength { get; set; }

    public DateTimeOffset AgreementStartDate { get; set; }

    public DateTimeOffset AgreementEndDate { get; set; }

    public Organization Organization { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}