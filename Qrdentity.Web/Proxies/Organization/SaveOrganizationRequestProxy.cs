using Qrdentity.Web.Proxies.Common;

namespace Qrdentity.Web.Proxies.Organization;

public sealed class SaveOrganizationRequestProxy
{
    public string ShortName { get; set; } = default!;

    public string LongName { get; set; } = default!;

    public string Alias { get; set; } = default!;

    public int? EmployeeCount { get; set; }

    public Guid TaxOfficeId { get; set; }

    public string TaxNumber { get; set; } = default!;

    public SaveOrganizationAddressRequestProxy Address { get; set; } = default!;

    public SaveOrganizationAgreementRequestProxy Agreement { get; set; } = default!;

    public List<Guid> BusinessSubTypes { get; set; } = new List<Guid>();

    public List<SaveContactInformationRequestProxy> Contacts { get; set; } =
        new List<SaveContactInformationRequestProxy>();
}