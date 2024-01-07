using Qrdentity.Web.Proxies.Common.Mobile;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;

namespace Qrdentity.Web.Proxies.Common.Vehicle;

public sealed class PreRegisterVehicleRequest
{
    public PlateNumberRequest Plate { get; set; } = default!;

    public MobileNumberRequest MobileNumber { get; set; } = default!;
}