using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Qrdentity.Web.Proxies.Common;
using Qrdentity.Web.Services;
using Qrdentity.Web.Utilities;

namespace Qrdentity.Web.Controllers.B2C;

[ApiController]
[Route("api/v1/users/{userId:guid}/operations")]
public sealed class UserOperationsController : QrdentityControllerBase
{
    private readonly ICodeGeneratorService _generatorService;

    private readonly IMemoryCache _memoryCache;

    public UserOperationsController(ICodeGeneratorService generatorService, IMemoryCache memoryCache)
    {
        _generatorService = generatorService;
        _memoryCache = memoryCache;
    }

    [HttpPost("generate-code")]
    public ActionResult<MultiFactorRegistrationSettingResponseProxy> GenerateCode([FromRoute] Guid userId,
        [FromQuery] string[]? mfCodes)
    {
        Dictionary<string, string> _mfCodes = (mfCodes == null || !mfCodes.Any()
                ? new string[] { "email-notification", "sms-notification" }
                : mfCodes)
            .Select((eachCode) =>
            {
                bool isExists = CacheUtility.ExistsVehiclePreRegistration(_memoryCache, userId, eachCode);
                if (!isExists)
                {
                    string code = _generatorService.Generate();
                    CacheUtility.SetVehiclePreRegistration(_memoryCache, userId, eachCode, code);
                    return new KeyValuePair<string, string>(eachCode, code);
                }

                string? codeInCache = CacheUtility.GetVehiclePreRegistration(_memoryCache, userId, eachCode);
                return new KeyValuePair<string, string>(eachCode, codeInCache ?? string.Empty);
            })
            .ToDictionary();

        MultiFactorRegistrationSettingResponseProxy responseProxy =
            (_mfCodes as MultiFactorRegistrationSettingResponseProxy)!;

        return Ok(_mfCodes);
    }
}