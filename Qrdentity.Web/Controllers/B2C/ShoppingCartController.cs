using Microsoft.AspNetCore.Mvc;
using Qrdentity.Web.Constants;
using Qrdentity.Web.Data.Cart;
using Qrdentity.Web.Mapping;
using Qrdentity.Web.Proxies.ShoppingCart;
using Qrdentity.Web.Services;

namespace Qrdentity.Web.Controllers.B2C;

[ApiController]
[Route("api/v1/cart/me")]
public class ShoppingCartController : QrdentityControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserShoppingCart(CancellationToken cancellationToken)
    {
        ShoppingCart userCart =
            await _shoppingCartService.GetShoppingCartOfUserAsync(DataConstants.AdminUserId,
                cancellationToken) ?? ShoppingCart.Create(DataConstants.AdminUserId);
        GetShoppingCartResponseProxy cartProxy = ShoppingCartMapping.ToShoppingCartProxy(userCart);
        return Ok(cartProxy);
    }

    [HttpGet("carts/{cartId:guid}")]
    public async Task<IActionResult> GetUserShoppingCartById([FromRoute] Guid cartId,
        CancellationToken cancellationToken)
    {
        ShoppingCart? userCart = await _shoppingCartService.GetShoppingCartByIdAsync(DataConstants.AdminUserId, cartId,
            cancellationToken);
        if (userCart == null)
        {
            return NotFound();
        }

        GetShoppingCartResponseProxy cartProxy = ShoppingCartMapping.ToShoppingCartProxy(userCart);
        return Ok(cartProxy);
    }

    [HttpPut]
    public async Task<IActionResult> AddToUserShoppingCart([FromBody] AddProductToShoppingCartRequestProxy proxy,
        CancellationToken cancellationToken)
    {
        ShoppingCart cart = await _shoppingCartService.AddToBasketAsync(DataConstants.AdminUserId, proxy.ProductId,
            proxy.Quantity <= 0 ? 1 : proxy.Quantity, cancellationToken);

        GetShoppingCartResponseProxy cartProxy = ShoppingCartMapping.ToShoppingCartProxy(cart);
        return Ok(cartProxy);
    }

    [HttpDelete("items/{cartItemId:guid}")]
    public async Task<IActionResult> RemoveCartItemFromShoppingCart([FromRoute] Guid cartItemId,
        [FromQuery] int quantity = 1,
        CancellationToken cancellationToken = default)
    {
        ShoppingCart cart =
            await _shoppingCartService.RemoveItemFromCartAsync(DataConstants.AdminUserId, cartItemId, quantity,
                cancellationToken);

        GetShoppingCartResponseProxy cartProxy = ShoppingCartMapping.ToShoppingCartProxy(cart);
        return Ok(cartProxy);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteShoppingCart(CancellationToken cancellationToken = default)
    {
        await _shoppingCartService.DeleteShoppingCartAsync(DataConstants.AdminUserId, cancellationToken);

        GetShoppingCartResponseProxy cartProxy =
            ShoppingCartMapping.ToShoppingCartProxy(ShoppingCart.Create(DataConstants.AdminUserId));
        return Ok(cartProxy);
    }
}