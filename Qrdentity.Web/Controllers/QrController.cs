using Microsoft.AspNetCore.Mvc;

namespace Qrdentity.Web.Controllers;

[ApiController]
[Route("api/v1/me/qr")]
public sealed class QrController(ILogger<QrController> logger) : QrdentityControllerBase
{
    private readonly ILogger<QrController> _logger = logger;
}