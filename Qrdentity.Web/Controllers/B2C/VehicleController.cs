using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.MultiFactor;
using Qrdentity.Web.Proxies.Common.Vehicle;
using Qrdentity.Web.Proxies.Vehicle;
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
    public async Task<IActionResult> VehiclePreRegistration([FromBody] PreRegisterVehicleRequest proxy,
        CancellationToken token)
    {
        MultiFactorRegistration? registration = await _vehicleService.PreRegisterVehicleAsync(DataConstants.AdminUserId,
            proxy.Mobile,
            DataConstants.AdminUserEmail, proxy.Plate,
            token);

        if (registration == null)
        {
            //TODO
            return BadRequest("Already sent registration code");
        }

        VehiclePreRegistrationResponse response = new VehiclePreRegistrationResponse
        {
            RegistrationId = registration.Id
        };
        return Ok(response);
    }

    [HttpPost]
    [Route("register-vehicle")]
    public async Task<IActionResult> VehicleRegistration([FromBody] ConfirmRegistrationRequest proxy,
        CancellationToken cancellationToken)
    {
        VehicleConfirmRegistrationResponse response = await _vehicleService.ConfirmRegistrationVehicleAsync(
            DataConstants.AdminUserId, proxy.RegistrationId,
            proxy.Code, cancellationToken);

        if (response.IsSuccess)
        {
            return Ok();
        }

        return BadRequest();
    }
}