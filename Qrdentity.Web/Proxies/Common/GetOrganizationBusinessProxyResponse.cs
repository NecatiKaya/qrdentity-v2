namespace Qrdentity.Web.Proxies.Common;

public sealed class GetOrganizationBusinessProxyResponse
{
    public Guid Id { get; set; }

    public Guid BusinessTypeId { get; set; }

    public Guid BusinessSubTypeId { get; set; }

    public string BusinessSubTypeName { get; set; } = default!;

    public string BusinessSubTypeDescriptions { get; set; } = default!;

    public string BusinessTypeName { get; set; } = default!;

    public string BusinessTypeDescriptions { get; set; } = default!;
}