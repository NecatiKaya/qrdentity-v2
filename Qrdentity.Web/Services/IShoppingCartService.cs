using Qrdentity.Web.Data.Cart;

namespace Qrdentity.Web.Services;

public interface IShoppingCartService
{
    Task<ShoppingCart?> GetShoppingCartOfUserAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<ShoppingCart> AddToBasketAsync(Guid basketOwnerId, Guid productId, int quantity = 1,
        CancellationToken cancellationToken = default);

    Task<ShoppingCart> RemoveItemFromCartAsync(Guid basketOwnerId, Guid cartItemId, int quantity = 1,
        CancellationToken cancellationToken = default);

    Task DeleteShoppingCartAsync(Guid basketOwnerId, CancellationToken cancellationToken = default);

    Task<ShoppingCart?> GetShoppingCartByIdAsync(Guid userId, Guid cartId, CancellationToken cancellationToken = default);
}