using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.MultiFactor;

namespace Qrdentity.Web.Services;

public sealed class SettingService : ISettingService
{
    private readonly QrdentityContext _qrdentityContext;

    public SettingService(QrdentityContext qrdentityContext)
    {
        _qrdentityContext = qrdentityContext;
    }

    public async Task<List<MultiFactorSetting>> LoadConfigurationAsync(bool? isActive = null,
        CancellationToken cancellationToken = default)
    {
        List<MultiFactorSetting> settings = await _qrdentityContext.MultiFactorSettings
            .Where(eachItem => isActive == null || eachItem.IsActive == isActive).AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return settings;
    }
}