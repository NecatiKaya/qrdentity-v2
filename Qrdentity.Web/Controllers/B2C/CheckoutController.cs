using Microsoft.AspNetCore.Mvc;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Proxies.Checkout;
using Qrdentity.Web.Services;

namespace Qrdentity.Web.Controllers.B2C;

[ApiController]
[Route("api/v1/checkout")]
public sealed class CheckoutController : QrdentityControllerBase
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    [HttpPost("{shoppingCartId:guid}")]
    public async Task<IActionResult> Complete([FromRoute] Guid shoppingCartId,
        [FromBody] CompleteCheckoutRequestProxy proxy,
        CancellationToken cancellationToken)
    {
        Guid userId = DataConstants.AdminUserId;
        await _checkoutService.Complete(userId, shoppingCartId, proxy, cancellationToken);
        return Ok();
    }
}