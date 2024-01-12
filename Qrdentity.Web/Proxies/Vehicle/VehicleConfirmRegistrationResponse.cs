namespace Qrdentity.Web.Proxies.Vehicle;

public sealed class VehicleConfirmRegistrationResponse
{
    public string MultiFactorSettingCode { get; set; } = default!;

    public string Value { get; set; } = default!;

    public bool IsAuthenticated { get; set; }
}