using Qrdentity.Web.Proxies.Common.Mobile;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;

namespace Qrdentity.Web.Services;

public interface IVehicleService
{
    Task PreRegisterVehicle(Guid userId, MobileNumberRequest? mobileNumber, string? email,
        PlateNumberRequest plateNumber, CancellationToken cancellationToken = default);
}