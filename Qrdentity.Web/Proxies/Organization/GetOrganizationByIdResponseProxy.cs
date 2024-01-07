using Qrdentity.Web.Proxies.Common;

namespace Qrdentity.Web.Proxies.Organization;

public sealed class GetOrganizationByIdResponseProxy
{
    public Guid Id { get; set; }

    public string ShortName { get; set; } = default!;

    public string LongName { get; set; } = default!;

    public string Alias { get; set; } = default!;

    public int? EmployeeCount { get; set; }

    public Guid TaxOfficeId { get; set; }

    public string TaxNumber { get; set; } = default!;

    public GetOrganizationAddressResponseProxy Address { get; set; } = default!;

    public List<GetOrganizationAgreementResponseProxy> Agreements { get; set; } =
        new List<GetOrganizationAgreementResponseProxy>();

    public List<GetOrganizationContactResponseProxy> Contacts { get; set; } =
        new List<GetOrganizationContactResponseProxy>();

    public List<GetOrganizationBusinessSubTypeResponseProxy> Businesses { get; set; } =
        new List<GetOrganizationBusinessSubTypeResponseProxy>();
}