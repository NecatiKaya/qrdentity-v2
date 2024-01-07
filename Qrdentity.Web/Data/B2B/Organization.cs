using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Core.Data;
using Qrdentity.Web.Data.B2B.Configurations;
using Qrdentity.Web.Data.Utility;

namespace Qrdentity.Web.Data.B2B;

[EntityTypeConfiguration(typeof(OrganizationConfiguration))]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class Organization : ITrackableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string ShortName { get; set; } = default!;

    public string LongName { get; set; } = default!;

    public string Alias { get; set; } = default!;

    public int? EmployeeCount { get; set; }

    public Guid TaxOfficeId { get; set; }

    public string TaxNumber { get; set; } = default!;

    public OrganizationAddress Address { get; set; } = default!;

    public ICollection<OrganizationAgreement> Agreements { get; set; } = new List<OrganizationAgreement>();

    public ICollection<OrganizationBusiness> Businesses { get; set; } =
        new List<OrganizationBusiness>();

    public ICollection<ContactInformation> Contacts { get; set; } = new List<ContactInformation>();

    public TaxOffice TaxOffice { get; set; } = default!;

    public DateTimeOffset CreatedDate { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}