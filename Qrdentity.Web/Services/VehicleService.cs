using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common.Mobile;
using Qrdentity.Web.Proxies.Common.Vehicle.PlateNumber;
using Qrdentity.Web.Proxies.Vehicle;
using Qrdentity.Web.Utilities;

namespace Qrdentity.Web.Services;

public sealed class VehicleService : IVehicleService
{
    private readonly QrdentityContext _qrdentityContext;

    private readonly IMemoryCache _memoryCache;

    public VehicleService(QrdentityContext qrdentityContext, IMemoryCache memoryCache)
    {
        _qrdentityContext = qrdentityContext;
        _memoryCache = memoryCache;
    }

    public async Task<MultiFactorRegistration?> PreRegisterVehicleAsync(Guid userId, MobileNumberRequest? mobileNumber,
        string? email,
        PlateNumberRequest plateNumber, CancellationToken cancellationToken = default)
    {
        bool exists = CacheUtility.ExistsVehiclePreRegistration(_memoryCache, userId);
        if (exists)
        {
            return null;
        }
        
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
        await _qrdentityContext.SaveChangesAsync(cancellationToken);

        CacheUtility.SetVehiclePreRegistration(_memoryCache, userId, registration.Id, codeToRegister);
        return registration;
    }

    public async Task<VehicleConfirmRegistrationResponse> ConfirmRegistrationVehicleAsync(Guid userId, Guid registrationId, string registrationCode,
        CancellationToken cancellationToken = default)
    {
        bool isValid =
            CacheUtility.ValidateVehiclePreRegistration(_memoryCache, userId, registrationId, registrationCode);

        if (isValid)
        {
            CacheUtility.ClearVehiclePreRegistration(_memoryCache, userId);

            MultiFactorRegistration? registration = await _qrdentityContext.MultiFactorRegistrations.Where(
                    eachRegistration =>
                        eachRegistration.Id == registrationId && eachRegistration.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (registration != null)
            {
                registration.IsAuthenticated = true;
            }
        }

        MultiFactorRegistrationHistory registrationHistory = new MultiFactorRegistrationHistory
        {
            UserId = userId,
            UsedMobileNumber = null,
            UsedEmail = null,
            UserProvidedCode = registrationCode
        };
        await _qrdentityContext.MultiFactorRegistrationHistory.AddAsync(registrationHistory, cancellationToken);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);

        return new VehicleConfirmRegistrationResponse()
        {
            IsSuccess = isValid
        };
    }
}