namespace Qrdentity.Web.Proxies.Common.Vehicle;

public sealed class ConfirmRegistrationRequest
{
    public Guid RegistrationId { get; set; }

    public List<MultiFactorRegistrationSettingRequestProxy> MfValues { get; set; } =
        new List<MultiFactorRegistrationSettingRequestProxy>();
}