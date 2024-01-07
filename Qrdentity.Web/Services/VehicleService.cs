using Qrdentity.Web.Data;
using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common.Mobile;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;

namespace Qrdentity.Web.Services;

public sealed class VehicleService : IVehicleService
{
    private readonly QrdentityContext _qrdentityContext;

    public VehicleService(QrdentityContext qrdentityContext)
    {
        _qrdentityContext = qrdentityContext;
    }

    public async Task PreRegisterVehicle(Guid userId, MobileNumberRequest? mobileNumber, string? email,
        PlateNumberRequest plateNumber, CancellationToken cancellationToken = default)
    {
        string codeToRegister = string.Join(string.Empty,
            Random.Shared.GetItems(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }, 6));

        MultiFactorRegistration registration = new MultiFactorRegistration
        {
            UserId = userId,
            MobileNumberToSendCode = mobileNumber?.ToString(),
            EmailToSendCode = !string.IsNullOrWhiteSpace(email) ? email : null,
            CodeToAuthenticate = codeToRegister
        };

        await _qrdentityContext.MultiFactorRegistrations.AddAsync(registration, cancellationToken);
    }
}