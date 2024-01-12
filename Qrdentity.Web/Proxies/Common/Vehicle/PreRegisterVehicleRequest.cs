using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;

namespace Qrdentity.Web.Proxies.Common.Vehicle;

public sealed class PreRegisterVehicleRequest
{
    public PlateNumberRequest Plate { get; set; } = default!;

    public List<MultiFactorRegistrationSettingRequestProxy> MfValues { get; set; } =
        new List<MultiFactorRegistrationSettingRequestProxy>();
}