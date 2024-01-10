using Qrdentity.Web.Data.MultiFactor;

namespace Qrdentity.Web.Services;

public interface ISettingService
{
    Task<List<MultiFactorSetting>> LoadConfigurationAsync(bool? isActive = null,
        CancellationToken cancellationToken = default);
}