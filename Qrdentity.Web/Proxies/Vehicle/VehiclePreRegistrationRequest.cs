namespace Qrdentity.Web.Proxies.Vehicle;

public sealed class VehiclePreRegistrationRequest
{
    public string MobileNumber { get; set; } = default!;

    public string PlateNumber { get; set; } = default!;
}