using Microsoft.AspNetCore.Mvc;
using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Mapping;
using Qrdentity.Web.Proxies.Setting;
using Qrdentity.Web.Services;

namespace Qrdentity.Web.Controllers;

[ApiController]
[Route("api/v1/settings")]
public sealed class SettingsController : QrdentityControllerBase
{
    private readonly ISettingService _configurationService;

    public SettingsController(ISettingService configurationService)
    {
        _configurationService = configurationService;
    }

    [HttpGet("multi-factors")]
    public async Task<IActionResult> GetMultiFactorConfigurations(CancellationToken cancellationToken)
    {
        List<MultiFactorSetting> settings = await _configurationService.LoadConfigurationAsync(true, cancellationToken);
        List<MultiFactorSettingProxy> proxies = settings.Select(MultiFactorMapping.ToMultiFactorSettingProxy).ToList();
        return Ok(proxies);
    }
}