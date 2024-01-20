using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> Complete([FromRoute] Guid shoppingCartId, [FromBody]CompleteCheckoutRequestProxy proxy,
        CancellationToken cancellationToken)
    {
        await _checkoutService.Complete(shoppingCartId, proxy, cancellationToken);
        return Ok();
    }
}