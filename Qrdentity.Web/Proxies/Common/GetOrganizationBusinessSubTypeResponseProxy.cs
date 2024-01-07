namespace Qrdentity.Web.Proxies.Common;

public sealed class GetOrganizationBusinessSubTypeResponseProxy
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Descriptions { get; set; } = default!;

    public Guid BusinessTypeId { get; set; }

    public string BusinessTypeName { get; set; } = default!;

    public string BusinessTypeDescriptions { get; set; } = default!;
}