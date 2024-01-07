using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common.Mobile;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;
using Qrdentity.Web.Proxies.Vehicle;

namespace Qrdentity.Web.Services;

public interface IVehicleService
{
    Task<MultiFactorRegistration?> PreRegisterVehicleAsync(Guid userId, MobileNumberRequest? mobileNumber, string? email,
        PlateNumberRequest plateNumber, CancellationToken cancellationToken = default);

    Task<VehicleConfirmRegistrationResponse> ConfirmRegistrationVehicleAsync(Guid userId, Guid registrationId, string registrationCode,
        CancellationToken cancellationToken = default!);
}