namespace Qrdentity.Web.Proxies.Common;

public sealed class SaveOrganizationAgreementRequestProxy
{
    public string FileName { get; set; } = default!;

    public string FileExtension { get; set; } = default!;

    public int FileLength { get; set; }

    public DateTimeOffset AgreementStartDate { get; set; }

    public DateTimeOffset AgreementEndDate { get; set; }
}