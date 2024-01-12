using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;
using Qrdentity.Web.Proxies.Vehicle;

namespace Qrdentity.Web.Services;

public interface IVehicleService
{
    Task<MultiFactorRegistrationGroup?> PreRegisterVehicleAsync(Guid userId, PlateNumberRequest plateNumber,
        List<MultiFactorRegistrationSettingRequestProxy> mfValues,
        CancellationToken cancellationToken = default);

    Task<List<VehicleConfirmRegistrationResponse>> ConfirmRegistrationVehicleAsync(Guid userId, Guid registrationGroupId,
        List<MultiFactorRegistrationSettingRequestProxy> mfValues,
        CancellationToken cancellationToken = default!);
}