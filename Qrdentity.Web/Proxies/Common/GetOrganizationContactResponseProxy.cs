namespace Qrdentity.Web.Proxies.Common;

public sealed class GetOrganizationContactResponseProxy
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}