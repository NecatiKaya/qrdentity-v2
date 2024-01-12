using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common;
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

    public async Task<MultiFactorRegistrationGroup?> PreRegisterVehicleAsync(Guid userId,
        PlateNumberRequest plateNumber,
        List<MultiFactorRegistrationSettingRequestProxy> mfValues,
        CancellationToken cancellationToken = default)
    {
        foreach (MultiFactorRegistrationSettingRequestProxy mfValue in mfValues)
        {
            if (string.IsNullOrWhiteSpace(mfValue.CodeToAuthenticate))
            {
                //TODO
                throw new Exception("");
            }
        }
        
        MultiFactorRegistrationGroup registration = new MultiFactorRegistrationGroup
        {
            UserId = userId
        };

        foreach (MultiFactorRegistrationSettingRequestProxy eachMfValue in mfValues)
        {
            MultiFactorRegistrationSetting setting = new MultiFactorRegistrationSetting
            {
                MultiFactorRegistrationGroupId = registration.Id,
                MultiFactorSettingId = eachMfValue.Code,
                Value = eachMfValue.Value,
                CodeToAuthenticate = eachMfValue.CodeToAuthenticate,
                IsAuthenticated = false,
                IsActive = true
            };
            await _qrdentityContext.MultiFactorRegistrationSettings.AddAsync(setting, cancellationToken);
        }

        await _qrdentityContext.MultiFactorRegistrationGroups.AddAsync(registration, cancellationToken);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);

        return registration;
    }

    public async Task<List<VehicleConfirmRegistrationResponse>> ConfirmRegistrationVehicleAsync(Guid userId,
        Guid registrationGroupId, List<MultiFactorRegistrationSettingRequestProxy> mfValues,
        CancellationToken cancellationToken = default)
    {
        MultiFactorRegistrationGroup? group = await _qrdentityContext.MultiFactorRegistrationGroups
            .Include(multiFactorRegistrationGroup => multiFactorRegistrationGroup.MultiFactorRegistrationSettings)
            .FirstOrDefaultAsync(
                eachGroup =>
                    eachGroup.Id == registrationGroupId && eachGroup.IsActive, cancellationToken: cancellationToken);

        if (group == null)
        {
            //TODO NKAYA
            throw new Exception("");
        }

        List<VehicleConfirmRegistrationResponse> response = new List<VehicleConfirmRegistrationResponse>();

        foreach (MultiFactorRegistrationSetting multiFactorRegistrationSetting in group.MultiFactorRegistrationSettings)
        {
            //Checking whether request proxy contains preconfirmed auth code.
            MultiFactorRegistrationSettingRequestProxy? setting = mfValues.Find(eachItem => string.Equals(eachItem.Code,
                multiFactorRegistrationSetting.MultiFactorSettingId,
                StringComparison.OrdinalIgnoreCase));
            if (setting != null)
            {
                string? codeInCache = CacheUtility.GetVehiclePreRegistration(_memoryCache, userId,
                    multiFactorRegistrationSetting.MultiFactorSettingId);
                if (string.IsNullOrWhiteSpace(codeInCache))
                {
                    response.Add(new VehicleConfirmRegistrationResponse
                    {
                        MultiFactorSettingCode = setting.Code,
                        Value = setting.Value,
                        IsAuthenticated = false
                    });
                    multiFactorRegistrationSetting.IsAuthenticated = false;
                }
                else
                {
                    bool isRegistrationSettingAuthenticated = string.Equals(setting.CodeToAuthenticate,
                        codeInCache, StringComparison.OrdinalIgnoreCase);

                    response.Add(new VehicleConfirmRegistrationResponse
                    {
                        MultiFactorSettingCode = setting.Code,
                        Value = setting.Value,
                        IsAuthenticated = isRegistrationSettingAuthenticated
                    });
                    multiFactorRegistrationSetting.IsAuthenticated = isRegistrationSettingAuthenticated;
                }
            }
        }

        await _qrdentityContext.SaveChangesAsync(cancellationToken);

        return response;
    }
}