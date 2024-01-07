using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Services;

namespace Qrdentity.Web.Controllers.B2C;

[ApiController]
[Route("api/v1/me/vehicles")]
public sealed class VehicleController : QrdentityControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly IMemoryCache _memoryCache;

    public VehicleController(IVehicleService vehicleService, IMemoryCache memoryCache)
    {
        _vehicleService = vehicleService;
        _memoryCache = memoryCache;
    }

    [HttpPost]
    [Route("pre-register-vehicle")]
    public async Task<IActionResult> VehiclePreRegistration(CancellationToken token)
    {
        await _vehicleService.PreRegisterVehicle(DataConstants.AdminUserId, null, DataConstants.AdminUserEmail, null, token);
        return Ok();
    }
}