namespace Qrdentity.Web.Proxies.Common.Vehicle;

public sealed class ConfirmRegistrationRequest
{
    public Guid RegistrationId { get; set; }

    public string Code { get; set; } = default!;
}