namespace Qrdentity.Web.Proxies.Common;

public sealed class GetOrganizationAgreementResponseProxy
{
    public Guid Id { get; set; }
    
    public string FileName { get; set; } = default!;

    public string FileExtension { get; set; } = default!;

    public int FileLength { get; set; }

    public DateTimeOffset AgreementStartDate { get; set; }

    public DateTimeOffset AgreementEndDate { get; set; }

    public bool IsActive { get; set; }
}