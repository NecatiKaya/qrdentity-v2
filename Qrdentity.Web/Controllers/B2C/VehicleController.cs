using Microsoft.AspNetCore.Mvc;
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

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpPost]
    [Route("pre-register-vehicle")]
    public async Task<ActionResult<VehiclePreRegistrationResponse>> VehiclePreRegistration([FromBody] PreRegisterVehicleRequest proxy,
        CancellationToken token)
    {
        MultiFactorRegistrationGroup? registration =
            await _vehicleService.PreRegisterVehicleAsync(DataConstants.AdminUserId, proxy.Plate, proxy.MfValues,
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
    public async Task<ActionResult<List<VehicleConfirmRegistrationResponse>>> VehicleRegistration([FromBody] ConfirmRegistrationRequest proxy,
        CancellationToken cancellationToken)
    {
        List<VehicleConfirmRegistrationResponse> response = await _vehicleService.ConfirmRegistrationVehicleAsync(
            DataConstants.AdminUserId, proxy.RegistrationId, proxy.MfValues, cancellationToken);
        return Ok(response);
    }
}